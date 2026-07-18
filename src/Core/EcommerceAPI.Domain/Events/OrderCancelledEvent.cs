using EcommerceAPI.Domain.Common;
using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Domain.Events
{
    public class OrderCancelledEvent : IDomainEvent
    {
        public Order Order { get; }
        public DateTime OccurredOn { get; }

        public OrderCancelledEvent(Order order)
        {
            Order = order;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
