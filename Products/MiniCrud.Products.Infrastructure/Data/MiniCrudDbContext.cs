using Microsoft.EntityFrameworkCore;
using MiniCrud.Products.Domain.Entities;
using MiniCrud.Products.Domain.Models.Mapping;

namespace MiniCrud.Products.Infrastructure.Data
{
    public class MiniCrudDbContext : DbContext
    {
        public MiniCrudDbContext(): base()
        {}
        public MiniCrudDbContext(DbContextOptions<MiniCrudDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMap).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql();
            }
        }

        public DbSet<Product>? Products { get; set; }
    }
}