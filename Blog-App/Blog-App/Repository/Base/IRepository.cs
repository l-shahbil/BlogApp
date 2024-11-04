using System.Linq.Expressions;

namespace Blog_App.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> filter);
        Task<T> GetByIdAsync(int id);
    }
}
