using API_.NET.Application.DTOs;
using API_.NET.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_.NET.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _authService.Login(request);
            if (user == null)
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }
}
