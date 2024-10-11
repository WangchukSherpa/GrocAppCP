using ProjWork.Entities;

namespace ProjWork.Repo.Interface
{
    public interface IGenericRepository<T> where T : BaseEntities
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task AddAsync(T entity);
        Task<int> SaveChangesAsync();

    }
}
