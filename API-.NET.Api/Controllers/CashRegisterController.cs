using API_.NET.Application.DTOs.Request;
using API_.NET.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_.NET.Api.Controllers
{
    [ApiController]
    [Route("api/v1/cash-register")]
    [Authorize]
    public class CashRegisterController : ControllerBase
    {
        private readonly CashRegisterService _service;
        public CashRegisterController(CashRegisterService service)
        {
            _service = service;
        }
        [HttpPost("open")]
        public async Task<IActionResult> Open(OpenCashRegisterRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result = await _service.Open(request, userId);
            return Ok(result);
        }
        [HttpPost("close")]
        public async Task<IActionResult> Close(CloseCashRegisterRequest request)
        {
            var result = await _service.Close(request);
            return Ok(result);
        }
        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(CashMovementRequest request)
        {
            var result = await _service.Withdraw(request);
            return Ok(result);
        }
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit(CashMovementRequest request)
        {
            var result = await _service.Deposit(request);
            return Ok(result);
        }
        [HttpGet("open")]
        public async Task<IActionResult> GetOpen()
        {
            var cash = await _service.GetOpen();
            return Ok(cash);
        }

    }
}
