using ProjWork.Entities.Order;

namespace ProjWork.Repo.Interface
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketId,
            Address shipingAddress);
    }
}
