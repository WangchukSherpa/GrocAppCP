using Microsoft.EntityFrameworkCore;
using ProjWork.Data;
using ProjWork.Entities;
using ProjWork.Entities.Order;
using ProjWork.Repo.Interface;


namespace ProjWork.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ProductDbContext _context;

        public OrderRepo(ProductDbContext context)
        {
            _context = context;
        }

      

        public async Task AddAsync(Order entity)
        {
            await _context.Set<Order>().AddAsync(entity);
        }

       

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _context.Set<Order>().FindAsync(id);
        }

        public async Task<IReadOnlyList<Order>> ListAllAsync()
        {
            return await _context.Set<Order>().ToListAsync();
        }
        public IQueryable<Order> GetOrders()
        {
            return _context.Orders
                .Include(o => o.OrderedItems)//
                .Include(o => o.DeliveryMethod)//
                .OrderByDescending(o=>o.DateTime)
                .AsQueryable();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


    }
}
