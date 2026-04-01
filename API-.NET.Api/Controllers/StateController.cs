using API_.NET.Application.DTOs.Request;
using API_.NET.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_.NET.Api.Controllers
{
    [Authorize]
    [Route("api/v1/state")]
    public class StateController : ControllerBase
    {
        private readonly StateService _stateService;
        public StateController(StateService stateService)
        {
            _stateService = stateService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateStateRequest request)
        {
            var isCreated = await _stateService.Create(request);
            if (isCreated == null)
            {
                return BadRequest();
            }
            return Created();
        }
    }
}
