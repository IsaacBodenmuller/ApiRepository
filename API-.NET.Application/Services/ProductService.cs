using API_.NET.Application.DTOs;
using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;

namespace API_.NET.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> Create(CreateProductRequest createProductRequest)
        {
            var product = new Product
            {
                Name = createProductRequest.Name,
                Description = createProductRequest.Description,
                Code = createProductRequest.Code,
                Price = createProductRequest.Price
            };
            await _productRepository.Create(product);
            return "Produto criado com sucesso";
        } 
    }
}
