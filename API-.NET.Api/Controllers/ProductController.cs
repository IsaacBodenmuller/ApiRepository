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
    }
}
