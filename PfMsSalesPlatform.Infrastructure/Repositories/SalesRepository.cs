using Microsoft.EntityFrameworkCore;
using PfMsSalesPlatform.Infrastructure.Context;

namespace PfMsSalesPlatform.Infrastructure.Repositories
{
    public class SalesRepository<T> : ISalesRepository<T> where T : class
    {
        private readonly SalesDBContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public SalesRepository(SalesDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<List<T>> GetAll() => await _dbSet.ToListAsync();

        public async Task<T?> GetAsync(int Id) => await _dbSet.FindAsync(Id);

        public async Task<T?> InsertAsync(T entity)
        {
            var entityResult = await _dbSet.AddAsync(entity);

            return entityResult.Entity;
        }

        public async Task<T?> UpdateAsync(int Id, T entity)
        {
            var findEntity = await _dbSet.FindAsync(Id);

            if (findEntity == null)
                return null;

            _dbContext.Entry(findEntity).CurrentValues.SetValues(entity);

            return entity;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var findEntity = await _dbSet.FindAsync(Id);

            if (findEntity == null)
                return false;

            _dbSet.Remove(findEntity);

            return true;
        }
    }
}
