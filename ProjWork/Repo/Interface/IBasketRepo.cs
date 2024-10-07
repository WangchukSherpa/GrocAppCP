using ProjWork.Entities.Basket;

namespace ProjWork.Repo.Interface
{
    public interface IBasketRepo
    {
        Task<CustomersBasket> GetBasketAsync(string basketId);
        Task<CustomersBasket> UpdateBasketAsync(CustomersBasket customersBasket);
       
        Task<bool> DeleteItemBasketAsync(int id);
    }
}
