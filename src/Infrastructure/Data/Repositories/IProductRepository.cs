using Domain.Entities;

namespace Infrastructure.Data.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product?> GetProductWithItemsAsync(int id);
}