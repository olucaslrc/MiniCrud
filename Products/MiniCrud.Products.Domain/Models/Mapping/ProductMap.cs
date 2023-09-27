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

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.Property(x => x.Deleted)
                .IsRequired();

            builder.Property(x => x.Registered)
                .IsRequired();

            builder.Property(x => x.LastUpdate)
                .IsRequired();

            builder.ToTable("Products");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Price).HasColumnName("Price");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.Deleted).HasColumnName("Deleted");
            builder.Property(x => x.Registered).HasColumnName("Registered");
            builder.Property(x => x.LastUpdate).HasColumnName("LastUpdate");
        }
    }
}
