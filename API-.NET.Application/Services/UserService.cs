using API_.NET.Application.DTOs;
using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;

namespace API_.NET.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Register(RegisterRequest registerRequest)
        {
            var user = new User
            {
                Name = registerRequest.Name,
                Email = registerRequest.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password)
            };

            await _userRepository.Create(user);

            return "Usuário criado com sucesso";
        }


    }
}
