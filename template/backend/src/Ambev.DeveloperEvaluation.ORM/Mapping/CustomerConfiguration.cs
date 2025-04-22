using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName)
              .IsRequired()
              .HasMaxLength(100);

        builder.Property(c => c.LastName)
              .IsRequired()
              .HasMaxLength(100);

        builder.Property(c => c.Email)
              .IsRequired()
              .HasMaxLength(200);

        builder.Property(c => c.PhoneNumber)
              .HasMaxLength(20);

        builder.Property(c => c.Document)
              .IsRequired()
              .HasMaxLength(20);

        builder.Property(c => c.DateOfBirth)
              .IsRequired();

        builder.Property(c => c.Password)
              .IsRequired()
              .HasMaxLength(255);

        builder.Property(c => c.CreatedOn)
            .IsRequired();
        
        builder.Property(c => c.UpdatedOn)
            .IsRequired();

        builder.Property(c => c.Active)
              .IsRequired();

        builder.HasMany(c => c.Addresses)
              .WithOne(a => a.Customer)
              .HasForeignKey(a => a.CustomerId)
              .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Orders)
              .WithOne(o => o.Customer)
              .HasForeignKey(o => o.CustomerId)
              .OnDelete(DeleteBehavior.Restrict);

        // Ignorar propriedades que não devem ser persistidas
        builder.Ignore(c => c.FullName);


    }
}
