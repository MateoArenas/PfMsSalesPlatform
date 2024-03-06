using Microsoft.EntityFrameworkCore;
using PfMsSalesPlatform.Infrastructure.Context;

namespace PfMsSalesPlatform.Infrastructure.Repositories.UnitWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SalesDBContext _DBContext;
        private bool _disposed;

        public UnitOfWork(SalesDBContext dBContext)
        {
            _DBContext = dBContext;
        }

        public void Commit()
        {
            _DBContext.SaveChanges();
        }

        public void Rollback()
        {
            foreach (var entry in _DBContext.ChangeTracker.Entries())
            {              
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    case EntityState.Modified:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        public ISalesRepository<T> SalesRepository<T>() where T : class
        {
            return new SalesRepository<T>(_DBContext);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _DBContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
