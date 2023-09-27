using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiniCrud.Domain.Entities;
using MiniCrud.Domain.Interfaces.Repositories;

namespace MiniCrud.Products.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MiniCrudDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(MiniCrudDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Add(Product entity)
        {
            try
            {
                await _context.AddAsync(entity);
                return true;
            }
            catch (DbException ex)
            {
                _logger.Log(LogLevel.Critical, ex.Message, _logger);
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(Product entity)
        {
            try
            {
                await _context.AddRangeAsync(entities: entity);
                return true;
            }
            catch (DbException ex)
            {
                _logger.Log(LogLevel.Critical, ex.Message, _logger);
                throw new Exception(ex.Message);
            }
        }

        public Task<bool> Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                return await _context.Products!.ToListAsync();
            }
            catch (DbException ex)
            {
                _logger.Log(LogLevel.Critical, ex.Message, _logger);
                throw new Exception(ex.Message);
            } 
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}