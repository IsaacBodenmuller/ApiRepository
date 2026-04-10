using API_.NET.Application.DTOs.Request;
using API_.NET.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_.NET.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var isCreated = await _userService.Create(request);
            if (isCreated == null)
            {
                return BadRequest();
            }
            return Created();
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _userService.GetUsers(page, pageSize);
            return Ok(result);
        }
    }
}
