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

        public async Task<AuthResponse> Login(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailOrUsername(request.Login);
            if (user == null) return null;

            var validPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!validPassword) return null;

            var accessToken = _tokenService.GenerateAccessToken(user, request.Remember);
            var refreshToken = _tokenService.GenerateRefreshToken();

            return new AuthResponse
            {
                AccessToken = accessToken,
                AccessExpiresIn = DateTime.UtcNow.AddMinutes(10),
                RefreshToken = refreshToken,
                RefreshExpiresIn = DateTime.UtcNow.AddMinutes(60)
            };
        }
        public async Task<AuthResponse> Refresh(RefreshRequest request)
        {
            var token = await _refreshTokenRepository.GetByToken(request.RefreshToken);

            if (token == null || token.IsRevoked || token.ExpiresAt < DateTime.UtcNow)
                throw new Exception("Refresh token inválido");

            token.IsRevoked = true;
            await _refreshTokenRepository.Update(token);

            var newAccessToken = _tokenService.GenerateAccessToken(token.User, request.Remember);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            await _refreshTokenRepository.Create(new RefreshToken
            {
                Token = newRefreshToken,
                UserId = token.UserId,
                ExpiresAt = DateTime.UtcNow.AddHours(8)
            });

            return new AuthResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }
        public async Task<string> Logout(LogoutRequest request)
        {
            var token = await _refreshTokenRepository.GetByToken(request.RefreshToken);

            if (token == null)
                return "Logout realizado";
            token.IsRevoked = true;

            await _refreshTokenRepository.Update(token);

            return "Logout realizado com sucesso";
        }
    }
}
