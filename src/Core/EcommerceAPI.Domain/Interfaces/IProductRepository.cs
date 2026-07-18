using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetBySkuAsync(string sku);
        Task<IReadOnlyList<Product>> GetProductsByCategoryAsync(int categoryId);
    }
}
