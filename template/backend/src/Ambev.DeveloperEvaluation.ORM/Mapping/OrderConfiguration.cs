using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.CustomerId).IsRequired();

        builder.Property(o => o.PaidOn);
        builder.Property(o => o.DeliveredOn);
        builder.Property( o => o.BranchId)
            .IsRequired();
        builder.Property(o => o.Status)
              .IsRequired();

        builder.Property(o => o.Discount)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

        builder.Property(o => o.ShippingValue)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

        builder.Property(o => o.TotalAmount)
              .HasColumnType("decimal(18,2)")
              .IsRequired();

        builder.Property(o => o.ShippingAddressId)
              .IsRequired();


        builder.Ignore(o => o.FinalAmount);
        builder.Ignore(o => o.CreatedOn);
        builder.Ignore(o => o.PaymentMethod);

        builder.HasOne(o => o.Customer)
              .WithMany(c => c.Orders)
              .HasForeignKey(o => o.CustomerId)
              .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(o => o.Items)
              .WithOne(i => i.Order)
              .HasForeignKey(i => i.OrderId)
              .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(o => o.ShippingAddress)
              .WithMany()
              .HasForeignKey(o => o.ShippingAddressId)
              .OnDelete(DeleteBehavior.Restrict);



    }
}
