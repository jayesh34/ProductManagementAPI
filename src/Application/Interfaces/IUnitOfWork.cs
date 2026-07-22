
using Domain.Entities;
namespace Application.Interfaces;

public interface IUnitOfWork
{
    IProductRepository Products { get; }

    Task<int> SaveChangesAsync();
}