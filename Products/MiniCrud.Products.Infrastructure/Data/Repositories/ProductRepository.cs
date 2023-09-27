using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiniCrud.Products.Domain.Entities;
using MiniCrud.Products.Domain.Interfaces;
using MiniCrud.Products.Domain.Interfaces.Repositories;

namespace MiniCrud.Products.Infrastructure.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MiniCrudDbContext context) : base(context)
        {
        }
    }
}