using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Infrastructure.Database.EntityFramework.Mapping;

public sealed class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category));

        builder.HasKey(k => k.Id);
        builder.Property(p => p.Description).HasColumnType("VARCHAR(250)");
        builder.Property(p => p.CreatedAt).HasColumnType("TIMESTAMP");        
    }
}