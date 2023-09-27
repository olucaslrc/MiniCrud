using Microsoft.EntityFrameworkCore;
using MiniCrud.Products.Domain.Interfaces.Repositories;
using System.Data.Common;
using System.Linq.Expressions;

namespace MiniCrud.Products.Infrastructure.Data.Repositories
{
    public abstract class Repository<T> : IRepositoryBase<T> where T : class
    {
        private bool disposedValue;
        protected MiniCrudDbContext _context;
        protected Repository(MiniCrudDbContext context)
        { 
            _context = context;
        }

        public async Task<bool> AddAsync(IEnumerable<T> entities)
        {
            try
            {
                await _context.AddRangeAsync(entities);
                await SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    var obj = await _context.FindAsync<T>(entity);
                    _context.Remove(obj!);
                }
                await SaveAsync();
                return true;
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Set<T>().FindAsync(id);

                if (result != null)
                {
                    return result;
                }
                return null;

            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(IEnumerable<T> entities)
        {
            try
            {

                foreach (var entity in entities)
                {
                    var get = await _context.Set<T>().FindAsync(entity);
                    _context.Update(get!);
                }
                await SaveAsync();
                return true;
            }
            catch (DbException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public async Task<Expression<T>>

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Repository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
