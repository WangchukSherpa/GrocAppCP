using ProjWork.Entities.Order;

namespace ProjWork.Repo.Interface
{
    public interface IDeliveryMethodRepo
    {
        Task<DeliveryMethod> GetByIdDeliveryAsync(int id);
        Task<IReadOnlyList<DeliveryMethod>> ListAllDeliveryAsync();
    }
}
