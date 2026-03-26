using API_.NET.Domain.Entities;

namespace API_.NET.Application.Interfaces
{
    public interface IProductRepository
    {
        Task Create(Product product);
    }
}
