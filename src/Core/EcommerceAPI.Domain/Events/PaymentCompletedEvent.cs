using EcommerceAPI.Domain.Common;
using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Domain.Events
{
    public class PaymentCompletedEvent : IDomainEvent
    {
        public Order Order { get; }
        public decimal Amount { get; }
        public DateTime OccurredOn { get; }

        public PaymentCompletedEvent(Order order, decimal amount)
        {
            Order = order;
            Amount = amount;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
