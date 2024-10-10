using Microsoft.EntityFrameworkCore;
using ProjWork.Data;
using ProjWork.Entities;
using ProjWork.Repo.Interface;

namespace ProjWork.Repo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntities
    {
        private readonly ProductDbContext _context;
        public GenericRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
