using API_.NET.Application.DTOs.Request;
using API_.NET.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_.NET.Api.Controllers
{
    [Authorize]
    [Route("api/v1/city")]
    public class CityController : ControllerBase
    {
        private readonly CityService _cityService;
        public CityController(CityService cityService)
        {
            _cityService = cityService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCityRequest request)
        {
            var isCreated = await _cityService.Create(request);
            if (isCreated == null)
            {
                return BadRequest();
            }
            return Created();
        }
    }
}

