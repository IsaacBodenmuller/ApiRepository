using API_.NET.Application.Interfaces;
using API_.NET.Application.DTOs.Response;
using API_.NET.Domain.Entities;
using API_.NET.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API_.NET.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailOrUsername(string login)
        {
            return await _context.Users
                .Include(x => x.Profile)
                .FirstOrDefaultAsync(x => x.Email == login || x.Username == login);
        }

        public async Task Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users
                .Include(x => x.Profile)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<(List<User>, int totalCount)> GetPaged(int page, int pageSize)
        {
            var query = _context.Users
                .Where(x => x.IsActive)
                .Include(x => x.Profile)
                .AsQueryable();

            var totalCount = await query.CountAsync();

            var users = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (users, totalCount);
        }
    }
}
