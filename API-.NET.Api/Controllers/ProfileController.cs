using API_.NET.Application.DTOs.Request;
using API_.NET.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_.NET.Api.Controllers
{
    [ApiController]
    [Route("api/v1/profile")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _profileService;
        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProfileRequest request)
        {
            await _profileService.Create(request);
            return Ok(request);
        }
        [HttpGet("profiles")]
        public async Task<IActionResult> GetAllProfiles()
        {
            return Ok(await _profileService.GetAllProfiles());
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateProfileRequest request)
        {
            await _profileService.Update(request);
            return Ok(request);
        }
        //[HttpDelete("delete")]
        //public async Task<IActionResult> Delete()
        //{

        //}

    }
}
