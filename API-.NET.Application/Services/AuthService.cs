using API_.NET.Application.DTOs;
using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using BCrypt.Net;

namespace API_.NET.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public AuthService(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<AuthResponse> Login(LoginRequest request)
        {
            var user = await _userRepository.GetByEmail(request.Email);
            if (user == null) return null;

            var validPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!validPassword) return null;

            var accessToken = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            return new AuthResponse
            {
                AccessToken = accessToken,
                AccessExpiresIn = DateTime.UtcNow.AddMinutes(10),
                RefreshToken = refreshToken,
                RefreshExpiresIn = DateTime.UtcNow.AddMinutes(60)
            };
        }
    }
}
