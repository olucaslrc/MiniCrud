using MiniCrud.Products.Domain.Entities;

namespace MiniCrud.Products.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>, IDisposable
    {
    }
}