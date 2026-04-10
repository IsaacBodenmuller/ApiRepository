using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using API_.NET.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API_.NET.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext _context;
        public ProfileRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Profile profile)
        {
            _context.Add(profile);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Profile>> GetAllProfiles()
        {
            return await _context.Profiles.Where(x => x.IsActive).ToListAsync();
        }
    }
}
