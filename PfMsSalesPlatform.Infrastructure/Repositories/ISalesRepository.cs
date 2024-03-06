namespace PfMsSalesPlatform.Infrastructure.Repositories
{
    public interface ISalesRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T?> GetAsync(int Id);
        public Task<T?> InsertAsync(T entity);
        public Task<T?> UpdateAsync(int Id, T entity);
        public Task<bool> DeleteAsync(int Id);
    }
}
