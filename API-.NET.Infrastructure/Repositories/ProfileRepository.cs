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
        public async Task Update(Profile profile, int id)
        {
            var findProfile = await _context.Profiles.FirstOrDefaultAsync(x => x.Id == id);

            if (findProfile == null)
                throw new Exception("Perfil não encontrado");

            findProfile.Name = profile.Name;
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var isUsing = await _context.Users
                .AnyAsync(x => x.ProfileId == id);

            if (isUsing)
                throw new Exception("Esse perfil está sendo utilizado por um usuário.");

            var rowsAffected = await _context.Profiles
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (rowsAffected == 0)
                throw new Exception("Perfil não encontrado");
        }

        public async Task<Profile?> GetById(int id)
        {
            return await _context.Profiles.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Profile>> GetAllProfiles()
        {
            return await _context.Profiles.Where(x => x.IsActive).ToListAsync();
        }
    }
}
