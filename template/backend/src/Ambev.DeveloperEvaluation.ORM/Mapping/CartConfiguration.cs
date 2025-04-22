using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.CustomerId)
              .IsRequired();

        builder.Property(c => c.CreatedOn)
              .IsRequired();

        builder.Property(c => c.UpdatedOn)
              .IsRequired();

        builder.Property(c => c.IsActive)
              .IsRequired();

        builder.HasMany(c => c.Items)
              .WithOne(i => i.Cart)
              .HasForeignKey(i => i.CartId)
              .OnDelete(DeleteBehavior.Cascade);

    }
}
