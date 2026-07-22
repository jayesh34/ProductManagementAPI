using Infrastructure.Data.Repositories;

namespace Infrastructure.Data;

public interface IUnitOfWork
{
    IProductRepository Products { get; }

    Task<int> SaveChangesAsync();
}