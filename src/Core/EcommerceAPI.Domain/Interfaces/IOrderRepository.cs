using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IReadOnlyList<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order?> GetOrderWithItemsAsync(int orderId);
    }
}
