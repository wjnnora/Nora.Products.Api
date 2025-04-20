using Nora.Core.Domain.Entities;

namespace Nora.Products.Domain.Entities;

public class Category : Entity<int>
{
    public string Description { get; private set; }

    private Category() { }

    public Category(string description)
    {
        Description = description;
    }
}