using API_.NET.Application.DTOs;
using API_.NET.Application.DTOs.Request;
using API_.NET.Application.DTOs.Response;
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

        public async Task<PagedResult<UserResponse>> GetUsers(int page, int pageSize)
        {
            var (users, totalCount) = await _userRepository.GetPaged(page, pageSize);

            var usersDto = users.Select(u => new UserResponse
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
            }).ToList();

            return new PagedResult<UserResponse>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                Data = usersDto
            };
        }

    }
}
