namespace EcommerceAPI.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 0, // Order placed but not processed
        Confirmed = 1, // Payment confirmed
        Processing = 2, // Order being prepared
        Shipped = 3, // Order shipped
        Delivered = 4, // Order delivered to customer
        Cancelled = 5, // Order cancelled
        Returned = 6, // Order returned by customer
    }
}
