using API_.NET.Application.DTOs;
using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using BCrypt.Net;

namespace API_.NET.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User?> Login(LoginRequest request)
        {
            var user = await _userRepository.GetByEmail(request.Email);
            if (user == null) return null;

            var validPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!validPassword) return null;

            return user;
        }
    }
}
