using API_.NET.Application.DTOs;
using API_.NET.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_.NET.Api.Controllers
{
    [ApiController]
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProductRequest createProductRequest)
        {
            var isCreated = await _productService.Create(createProductRequest);
            if (isCreated == null)
            {
                return BadRequest();
            }
            return Created();
        }

        [Authorize]
        [HttpGet("products")]
        public async Task<IActionResult> GetProducts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _productService.GetProducts(page, pageSize);
            return Ok(result);
        }
    }
}
