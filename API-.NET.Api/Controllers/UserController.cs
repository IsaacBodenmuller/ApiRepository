using API_.NET.Application.DTOs;
using API_.NET.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_.NET.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var isCreated = await _userService.Register(request);
            if (isCreated == null)
            {
                return BadRequest();
            }
            return Created();
        }

        [Authorize]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _userService.GetUsers(page, pageSize);
            return Ok(result);
        }
    }
}
