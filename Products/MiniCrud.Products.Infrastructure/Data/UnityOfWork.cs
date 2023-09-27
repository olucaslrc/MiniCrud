using Microsoft.Extensions.Logging;
using MiniCrud.Products.Domain.Interfaces;
using MiniCrud.Products.Domain.Interfaces.Repositories;
using MiniCrud.Products.Infrastructure.Data.Repositories;

namespace MiniCrud.Products.Infrastructure.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly MiniCrudDbContext? _context;

        public UnityOfWork(MiniCrudDbContext context)
        {
            _context = context;
        }

        private IProductRepository? _productRepository;
        public IProductRepository ProductRepository 
        { 
            get 
            {
                _productRepository ??= new ProductRepository(_context!);
                return _productRepository!;
            } 
        }
    }
}
