using ProjWork.Entities.Order;
using ProjWork.Entities.User;

namespace ProjWork.Repo.Interface
{
    public interface IUserRepository
    {
 
        Task<Address> GetUserStoredAddressAsync(string email);
    }
}
