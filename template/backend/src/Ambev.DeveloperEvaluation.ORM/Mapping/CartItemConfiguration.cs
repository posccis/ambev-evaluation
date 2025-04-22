using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("CartItems");
        builder.HasKey(e => e.Id);

        builder
            .HasOne(ci => ci.Cart)
            .WithMany(c => c.Items)
            .HasForeignKey(ci => ci.CartId);

        builder.Property(e => e.ProductName)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(e => e.UnitPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.Total)
            .HasComputedColumnSql("[UnitPrice] * [Quantity]");

    }
}
