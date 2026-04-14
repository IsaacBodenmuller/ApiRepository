using API_.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Application.Interfaces
{
    public interface IProfileRepository
    {
        Task Create(Profile profile);
        Task Update(Profile profile, int id);
        Task Delete(int id);
        Task<Profile?> GetById(int id);
        Task<List<Profile>> GetAllProfiles();
    }
}
