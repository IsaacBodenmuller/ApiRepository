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
        public async Task<string> Register(RegisterRequest request)
        {

            var user = new User
            {
                Name = request.Name,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                ProfileId = request.ProfileId
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
                Username = u.Username,
                Email = u.Email,
                Profile = u.Profile
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
