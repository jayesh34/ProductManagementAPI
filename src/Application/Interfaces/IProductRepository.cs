using Domain.Entities;

namespace Application.Interfaces;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<Product?> GetProductWithItemsAsync(int id);
}