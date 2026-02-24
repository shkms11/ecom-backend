namespace EcommerceAPI.Domain.Enums
{
    public enum PaymentStatus
    {
        Pending = 0, // Payment initiated but not completed
        Completed = 1, // Payment successful
        Failed = 2, // Payment failed
        Refunded = 3, // Payment refunded
    }
}
