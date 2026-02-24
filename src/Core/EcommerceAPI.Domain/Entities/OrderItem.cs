namespace EcommerceAPI.Domain.Entities;

public class OrderItem
{
    private OrderItem() { }

    public OrderItem(Guid productId, decimal unitPrice, int quantity)
    {
        if (productId == Guid.Empty)
            throw new ArgumentException("ProductId is required.");

        if (unitPrice <= 0)
            throw new ArgumentException("Unit price must be greater than zero.");

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public Guid ProductId { get; private set; }
    public Product Product { get; private set; } = default!;

    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }

    public decimal TotalPrice => UnitPrice * Quantity;

    public Guid OrderId { get; private set; }
    public Order Order { get; private set; } = default!;

    internal void IncreaseQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Invalid quantity.");

        Quantity += quantity;
    }
}
