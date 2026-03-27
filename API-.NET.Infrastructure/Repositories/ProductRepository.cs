using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using API_.NET.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace API_.NET.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<(List<Product>, int totalCount)> GetPaged(int page, int pageSize)
        {
            var query = _context.Products.AsQueryable();

            var totalCount = await query.CountAsync();
            
            var products = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            
            return (products, totalCount);
        }
    }
}
