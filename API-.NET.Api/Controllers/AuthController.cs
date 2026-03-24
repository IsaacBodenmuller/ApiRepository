using API_.NET.Application.DTOs;
using API_.NET.Application.Services;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Login([FromQuery] string email, [FromQuery] string password)
        {
            var request = new LoginRequest
            {
                Email = email,
                Password = password
            };
            var result = await _authService.Login(request);
            if (result == null)
                return Unauthorized("Email ou senha inválidos");
            
            return Ok(result);
        }
    }
}
