using EcommerceAPI.Domain.Common;
using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Domain.Events
{
    public class StockDecreasedEvent : IDomainEvent
    {
        public Product Product { get; }
        public int Quantity { get; }
        public DateTime OccurredOn { get; }

        public StockDecreasedEvent(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
