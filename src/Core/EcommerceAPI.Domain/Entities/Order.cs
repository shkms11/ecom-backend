using EcommerceAPI.Domain.Common;
using EcommerceAPI.Domain.Enums;
using EcommerceAPI.Domain.Events;

namespace EcommerceAPI.Domain.Entities;

public class Order : AuditableEntity
{
    private readonly List<OrderItem> _items = new();

    private Order() { }

    public Order(Guid userId)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("UserId is required.");

        UserId = userId;
        Status = OrderStatus.Pending;
    }

    public Guid UserId { get; private set; }
    public User User { get; private set; } = default!;

    public OrderStatus Status { get; private set; }

    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public decimal TotalAmount => _items.Sum(i => i.TotalPrice);

    public void AddItem(Guid productId, decimal unitPrice, int quantity)
    {
        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Cannot modify a non-pending order.");

        var existingItem = _items.FirstOrDefault(i => i.ProductId == productId);

        if (existingItem is not null)
        {
            existingItem.IncreaseQuantity(quantity);
            return;
        }

        var item = new OrderItem(productId, unitPrice, quantity);
        _items.Add(item);
    }

    public void Confirm()
    {
        if (!_items.Any())
            throw new InvalidOperationException("Order must contain at least one item.");

        if (Status != OrderStatus.Pending)
            throw new InvalidOperationException("Only pending orders can be confirmed.");

        Status = OrderStatus.Confirmed;

        AddDomainEvent(new OrderPlacedEvent(this));
    }

    public void Ship()
    {
        if (Status != OrderStatus.Confirmed)
            throw new InvalidOperationException("Only confirmed orders can be shipped.");

        Status = OrderStatus.Shipped;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Shipped || Status == OrderStatus.Delivered)
            throw new InvalidOperationException(
                "Cannot cancel an order that has already been shipped."
            );

        if (Status == OrderStatus.Cancelled)
            throw new InvalidOperationException("Order is already cancelled.");

        Status = OrderStatus.Cancelled;
    }
}
