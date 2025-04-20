using Nora.Core.Domain.Entities;

namespace Nora.Products.Domain.Entities;

public class Product : Entity<int>
{
    public string Description { get; private set; }
    public decimal Value { get; private set; }
    public int CategoryId { get; private set; }
    public virtual Category Category { get; private set; }

    private Product() { }

    public Product(string description, decimal value)
    {
        Description = description;
        Value = value;
    }
}