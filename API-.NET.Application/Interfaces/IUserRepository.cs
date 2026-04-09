using API_.NET.Domain.Entities;

namespace API_.NET.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailOrUsername(string login); 
        Task Create(User user);
        Task<(List<User>, int totalCount)> GetPaged(int page, int pageSize);
    }
}
