using API_.NET.Application.DTOs.Request;
using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_.NET.Application.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<string> Create(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };
            await _categoryRepository.Create(category);
            return "Categoria criada com suscesso";
        }

    }
}
