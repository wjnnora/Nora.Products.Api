using Microsoft.EntityFrameworkCore;
using Nora.Core.Database.Postgres.EntityFramework;
using Nora.Products.Domain.Contracts.Repositories;
using Nora.Products.Domain.Entities;

namespace Nora.Products.Infrastructure.Database.EntityFramework.Repositories;

public sealed class CategoryRepository(AppDbContext context) : AbstractRepository<Category, int>(context), ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetByDescriptionAsync(string description)
    {
        return await DbSet
            .Where(x => x.Description.Equals(description))
            .ToListAsync();
    }
}
