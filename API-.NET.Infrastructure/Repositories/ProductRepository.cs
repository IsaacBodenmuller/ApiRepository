using API_.NET.Application.Interfaces;
using API_.NET.Domain.Entities;
using API_.NET.Infrastructure.Persistence;

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
    }
}
