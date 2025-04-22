using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
               .IsRequired();

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.Description)
               .HasMaxLength(500);

        builder.Property(p => p.Price)
               .HasColumnType("decimal(18,2)")
               .IsRequired();

        builder.Property(p => p.StockQuantity)
               .IsRequired();

        builder.Property(p => p.SKU)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(p => p.CategoryId)
               .IsRequired();

        builder.Property(p => p.IsActive)
               .HasDefaultValue(true);

        builder.Property(p => p.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        builder.Property(p => p.UpdatedAt)
               .IsRequired(false);

        builder.Property(p => p.ImageUrl)
               .HasMaxLength(300);

        builder.Property(p => p.DiscountPrice)
               .HasColumnType("decimal(18,2)")
               .IsRequired(false);

    }
}
