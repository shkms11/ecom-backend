using EcommerceAPI.Domain.Common;

namespace EcommerceAPI.Domain.Entities;

public class Product : AuditableEntity
{
    private Product() { } // EF Core

    public Product(string name, string description, decimal price, int stock, Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required.");

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        if (stock < 0)
            throw new ArgumentException("Stock cannot be negative.");

        if (categoryId == Guid.Empty)
            throw new ArgumentException("CategoryId is required.");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        CategoryId = categoryId;
        IsActive = true;
    }

    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public bool IsActive { get; private set; }

    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; } = default!;

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("Price must be greater than zero.");

        Price = newPrice;
    }

    public void ReduceStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Invalid quantity.");

        if (Stock < quantity)
            throw new InvalidOperationException("Insufficient stock.");

        Stock -= quantity;
    }

    public void IncreaseStock(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Invalid quantity.");

        Stock += quantity;
    }

    public void Deactivate()
    {
        IsActive = false;
    }
}
