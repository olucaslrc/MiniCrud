using MiniCrud.Products.Domain.Interfaces.Repositories;

namespace MiniCrud.Products.Domain.Interfaces
{
    public interface IUnityOfWork
    {
        public IProductRepository ProductRepository { get; }
    }
}
