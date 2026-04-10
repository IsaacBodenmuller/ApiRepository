using API_.NET.Application.DTOs.Request;
using API_.NET.Application.DTOs.Response;
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
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var (response, refreshToken) = await _authService.Login(request);

            if (response == null || string.IsNullOrEmpty(refreshToken))
                return Unauthorized("Email ou senha inválidos");

            Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(2),
            });
            
            return Ok(response);
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(refreshToken))
                return Unauthorized("Refresh token não encontrado");

            var (response, newRefreshToken) = await _authService.Refresh(refreshToken);

            if (response == null)
                return Unauthorized("Refresh token inválido");

            Response.Cookies.Append("refreshToken", newRefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(2),
            });

            return Ok(response);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!string.IsNullOrEmpty(refreshToken)) 
            {
                await _authService.Logout(refreshToken);
            }

            Response.Cookies.Delete("refreshToken");

            return Ok("Logout realizado");
        }
    }
}
