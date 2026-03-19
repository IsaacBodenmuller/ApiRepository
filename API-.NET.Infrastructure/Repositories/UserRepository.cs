using API_.NET.Application.Interfaces;
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

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
