using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Infrastructure.Database.EntityFramework.Mapping;

public sealed class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));

        builder.HasKey(k => k.Id);
        builder.Property(p => p.Description).HasColumnType("VARCHAR(250)");
        builder.Property(p => p.Value).HasColumnType("DECIMAL(18,2)");
        builder.Property(p => p.CreatedAt).HasColumnType("TIMESTAMP");

        builder.HasOne(x => x.Category);
    }
}