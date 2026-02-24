using EcommerceAPI.Domain.Common;

namespace EcommerceAPI.Domain.Entities;

public class Category : AuditableEntity
{
    private readonly List<Product> _products = new();

    private Category() { } // EF Core

    public Category(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name is required.");

        Name = name;
    }

    public string Name { get; private set; } = default!;

    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
}
