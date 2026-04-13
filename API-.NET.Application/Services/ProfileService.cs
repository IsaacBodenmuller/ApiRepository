using API_.NET.Application.DTOs.Request;
using API_.NET.Application.DTOs.Response;
using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Application.Services
{
    public class ProfileService
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public async Task Create(CreateProfileRequest request)
        {
            var profile = new Profile
            {
                Name = request.Name,
                IsActive = true
            };
            await _profileRepository.Create(profile);
        }
        public async Task Update(UpdateProfileRequest request)
        {
            var profile = new Profile
            {
                Name = request.Name,
                IsActive = true
            };
            await _profileRepository.Update(profile);
        }
        public async Task<List<ProfileResponse>> GetAllProfiles()
        {
            var profiles = await _profileRepository.GetAllProfiles();
            return profiles.Select(p => new ProfileResponse
            {
                Id = p.Id,
                Name = p.Name,
                IsActive = p.IsActive,            
            }).ToList();
        }
    }
}
