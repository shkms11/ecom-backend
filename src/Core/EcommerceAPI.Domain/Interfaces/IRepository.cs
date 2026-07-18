using EcommerceAPI.Domain.Common;

namespace EcommerceAPI.Domain.Interfaces
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
