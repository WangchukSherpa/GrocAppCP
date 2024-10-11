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

        public void Add(T entity)
        {
          _context.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);  // Assuming you're using Entity Framework
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<int> SaveChangesAsync() { 
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State= EntityState.Modified;
        }
    }
}
