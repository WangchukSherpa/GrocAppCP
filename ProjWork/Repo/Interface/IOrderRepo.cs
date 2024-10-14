using ProjWork.Entities.Order;

namespace ProjWork.Repo.Interface
{
    public interface IOrderRepo
    {
        Task<Order> GetByIdAsync(int id);
        Task<IReadOnlyList<Order>> ListAllAsync();
       
        Task AddAsync(Order entity);
        Task<int> SaveChangesAsync();
        IQueryable<Order> GetOrders();
    }
}
