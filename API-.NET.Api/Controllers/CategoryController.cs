using API_.NET.Application.DTOs.Request;
using API_.NET.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_.NET.Api.Controllers
{
    [ApiController]
    [Route("api/v1/category")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateCategoryRequest createCategoryRequest)
        {
            var isCreated = await _categoryService.Create(createCategoryRequest);
            if(isCreated == null)
            {
                return BadRequest();
            }
            return Created();
        }

    }
}
