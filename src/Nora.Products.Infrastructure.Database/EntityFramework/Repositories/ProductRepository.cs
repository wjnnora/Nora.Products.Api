using Microsoft.EntityFrameworkCore;
using Nora.Core.Database.Postgres.EntityFramework;
using Nora.Products.Domain.Contracts.Repositories;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Infrastructure.Database.EntityFramework.Repositories;

public sealed class ProductRepository(AppDbContext context) : AbstractRepository<Product, int>(context), IProductRepository
{
    public override Task<Product> GetByIdAsync(int id)
    {
        return DbSet
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}