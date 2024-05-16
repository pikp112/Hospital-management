using System.Linq.Expressions;

namespace Hospital.Repositories.Interfaces
{
    public interface IGenericRepository<T> : IDisposable
    {
        T GetById(object id);

        Task<T> GetByIdAsync(object id);

        void Add(T entity);

        Task<T> AddAsync(T entity);

        void Update(T entity);

        Task<T> UpdateAsync(T entity);

        void Delete(T entity);

        Task<T> DeleteAsync(T entity);

        IReadOnlyCollection<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includProperties = "");
    }
}