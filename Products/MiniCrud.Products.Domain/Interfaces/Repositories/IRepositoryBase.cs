namespace MiniCrud.Products.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> : IDisposable where T : class
    {
        Task<bool> AddAsync(IEnumerable<T> entities);
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> UpdateAsync(IEnumerable<T> entities);
        Task<bool> DeleteAsync(IEnumerable<T> entities);
        Task<bool> SaveAsync();
    }
}