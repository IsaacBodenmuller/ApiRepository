using API_.NET.Application.DTOs.Request;
using API_.NET.Application.DTOs.Response;
using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using BCrypt.Net;

namespace API_.NET.Application.Services
{
    public class AuthService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public AuthService(IUserRepository userRepository, TokenService tokenService, IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<(AuthResponse? response, string? refreshToken)> Login(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailOrUsername(request.Login);
            if (user == null) return (null, null);

            var validPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!validPassword) return (null, null);

            var accessToken = _tokenService.GenerateAccessToken(user, request.Remember);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _refreshTokenRepository.Create(new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60)
            });

            var response = new AuthResponse
            {
                AccessToken = accessToken,
                AccessExpiresIn = DateTime.UtcNow.AddMinutes(10),
            };

            return (response, refreshToken);
        }
        public async Task<(AuthResponse? response, string? resfreshToken)> Refresh(string refreshToken)
        {
            var token = await _refreshTokenRepository.GetByToken(refreshToken);

            if (token == null || token.IsRevoked || token.ExpiresAt < DateTime.UtcNow)
                return (null, null);

            token.IsRevoked = true;
            await _refreshTokenRepository.Update(token);

            var newAccessToken = _tokenService.GenerateAccessToken(token.User, remember: true);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            await _refreshTokenRepository.Create(new RefreshToken
            {
                Token = newRefreshToken,
                UserId = token.UserId,
                ExpiresAt = DateTime.UtcNow.AddHours(8)
            });

            var response = new AuthResponse
            {
                AccessToken = newAccessToken,
                AccessExpiresIn = DateTime.UtcNow.AddMinutes(20),
            };
            return (response, newRefreshToken);
        }
        public async Task Logout(string refreshToken)
        {
            var token = await _refreshTokenRepository.GetByToken(refreshToken);

            if (token != null)
            { 
                token.IsRevoked = true;
                await _refreshTokenRepository.Update(token);
            }
        }
    }
}
