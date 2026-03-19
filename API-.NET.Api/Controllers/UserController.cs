using API_.NET.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_.NET.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await _authService.Register(request);

            return Created();
        }
    }
}
