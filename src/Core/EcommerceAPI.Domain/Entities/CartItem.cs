using EcommerceAPI.Domain.Common;

namespace EcommerceAPI.Domain.Entities;

public class CartItem : AuditableEntity
{
    public Guid CartId { get; private set; }

    public virtual Cart Cart { get; private set; } = null!;

    public Guid ProductId { get; private set; }

    public virtual Product Product { get; private set; } = null!;

    public int Quantity { get; private set; }

    private CartItem() { } // EF Core

    public CartItem(Guid productId, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        ProductId = productId;
        Quantity = quantity;
    }

    public void IncreaseQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        Quantity += quantity;
    }

    public void UpdateQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        Quantity = quantity;
    }
}
