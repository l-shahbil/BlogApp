using Blog_App.Data;
using Blog_App.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog_App.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbConext;

        public MainRepository(AppDbContext dbConext)
        {
            _dbConext = dbConext;
        }

        public async Task AddAsync(T entity)
        {
            await _dbConext.Set<T>().AddAsync(entity);
            _dbConext.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbConext.Set<T>().Update(entity);
            _dbConext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbConext.Set<T>().Remove(entity);
            _dbConext.SaveChanges();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _dbConext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbConext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbConext.Set<T>().Where(filter).ToListAsync();
        }
    }

}
