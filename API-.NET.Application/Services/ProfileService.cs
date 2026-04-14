using API_.NET.Application.DTOs.Request;
using API_.NET.Application.DTOs.Response;
using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task Update(UpdateProfileRequest request, int id)
        {
            var profile = new Profile
            {
                Name = request.Name,
                IsActive = true
            };
            await _profileRepository.Update(profile, id);
        }
        public async Task Delete(int id)
        {
            await _profileRepository.Delete(id);
        }
        public async Task<ProfileResponse> GetById(int id)
        {
            var profile = await _profileRepository.GetById(id);
            if (profile == null)
                throw new Exception("Nenhum registro encontrado");

            return new ProfileResponse
            {
                Id = id,
                Name = profile.Name,
                IsActive = profile.IsActive,
            };
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
