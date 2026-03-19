using API_.NET.Domain.Entities;

namespace API_.NET.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmail(string email);
        Task Create(User user);
    }
}
