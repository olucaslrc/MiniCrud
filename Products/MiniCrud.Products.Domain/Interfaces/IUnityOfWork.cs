using MiniCrud.Products.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCrud.Products.Domain.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        Task<bool> SaveAsync();
    }
}
