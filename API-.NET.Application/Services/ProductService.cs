using API_.NET.Application.DTOs;
using API_.NET.Application.DTOs.Request;
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

        public async Task<string> Create(CreateProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Code = request.Code,
                Barcode = request?.Barcode,
                CategoryId = request.CategoryId,
                SupplierId = request.SupplierId,
                CostPrice = request.CostPrice,
                SalePrice = request.SalePrice,
                UnitType = request.UnitType,
                Stock = 0,
                MinStock = 0,
                UpdatedAt = DateTime.UtcNow
            };
            await _productRepository.Create(product);
            return "Produto criado com sucesso";
        }

        public async Task<PagedResult<Product>> GetProducts(int page, int pageSize)
        {
            var (products, totalCount) = await _productRepository.GetPaged(page, pageSize);
            return new PagedResult<Product>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                Data = products
            };
        }
    }
}
