using Microsoft.EntityFrameworkCore;
using ProjWork.Data;
using ProjWork.Entities.Order;
using ProjWork.Repo.Interface;

namespace ProjWork.Repo
{
    public class DeliveryMethodRepo : IDeliveryMethodRepo
    {
        private readonly ProductDbContext _context;

        public DeliveryMethodRepo(ProductDbContext context) 
        {
            _context = context;
        }
        public async Task<DeliveryMethod> GetByIdDeliveryAsync(int id)
        {
            return await _context.Set<DeliveryMethod>().FindAsync(id);
        }

        public async Task<IReadOnlyList<DeliveryMethod>> ListAllDeliveryAsync()
        {
            // Use the base method from GenericRepository
            return await _context.Set<DeliveryMethod>().ToListAsync();
        }

    }
}
