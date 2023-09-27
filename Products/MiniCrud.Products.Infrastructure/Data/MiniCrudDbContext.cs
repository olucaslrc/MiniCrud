using Microsoft.EntityFrameworkCore;
using MiniCrud.Products.Domain.Entities;

namespace MiniCrud.Products.Infrastructure.Data
{
    public class MiniCrudDbContext : DbContext
    {
        public MiniCrudDbContext(DbContextOptions<MiniCrudDbContext> options) : base(options)
        {}

        public DbSet<Product>? Products { get; set; }
    }
}