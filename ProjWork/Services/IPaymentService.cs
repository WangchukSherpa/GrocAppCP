using ProjWork.Entities.Basket;

namespace ProjWork.Services
{
    public interface IPaymentService
    {
        Task<CustomersBasket> CreateOrUpdatePayment(string basketId);
    }
}
