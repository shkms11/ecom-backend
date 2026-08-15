using EcommerceAPI.Domain.Common;

namespace EcommerceAPI.Domain.Entities;

public class Cart : AuditableEntity
{
    public Guid UserId { get; private set; }

    public virtual User User { get; private set; } = null!;

    public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();

    private Cart() { } // EF Core

    public Cart(Guid userId)
    {
        UserId = userId;
    }

    public void AddItem(Guid productId, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);

        if (existingItem is not null)
        {
            existingItem.IncreaseQuantity(quantity);
            return;
        }

        Items.Add(new CartItem(productId, quantity));
    }

    public void UpdateQuantity(Guid productId, int quantity)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);

        if (item is null)
            throw new InvalidOperationException("Cart item not found.");

        if (quantity <= 0)
        {
            Items.Remove(item);
            return;
        }

        item.UpdateQuantity(quantity);
    }

    public void RemoveItem(Guid productId)
    {
        var item = Items.FirstOrDefault(i => i.ProductId == productId);

        if (item is not null)
        {
            Items.Remove(item);
        }
    }

    public void Clear()
    {
        Items.Clear();
    }
}
