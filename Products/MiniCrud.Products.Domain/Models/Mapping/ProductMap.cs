using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniCrud.Products.Domain.Entities;

namespace MiniCrud.Products.Domain.Models.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Price);
            builder.Property(x => x.Deleted).IsRequired();
            builder.Property(x => x.Registered).IsRequired();
            builder.Property(x => x.LastUpdate).IsRequired();
        }
    }
}
