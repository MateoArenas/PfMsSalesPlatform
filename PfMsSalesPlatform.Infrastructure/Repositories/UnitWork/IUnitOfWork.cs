namespace PfMsSalesPlatform.Infrastructure.Repositories.UnitWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        ISalesRepository<T> SalesRepository<T>() where T : class;
    }
}
