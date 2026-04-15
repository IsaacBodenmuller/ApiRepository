using API_.NET.Application.DTOs.Request;
using API_.NET.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_.NET.Api.Controllers
{
    [ApiController]
    [Route("api/v1/profiles")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _profileService;
        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProfileRequest request)
        {
            await _profileService.Create(request);
            return Ok(request);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            return Ok(await _profileService.GetAllProfiles());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profile = await _profileService.GetById(id);
            if (profile == null) 
                return NotFound();

            return Ok(profile);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProfileRequest request)
        {
            await _profileService.Update(request, id);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _profileService.Delete(id);
            return NoContent();
        }

    }
}
