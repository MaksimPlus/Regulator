using Microsoft.EntityFrameworkCore;
using Regulator.API.Data;
using Regulator.API.Interfaces;

namespace Regulator.API.Implementations
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        private RegulatorContext _context;
        private DbSet<T> _objectSet;
        private bool _disposed = false;

        public SqlRepository(RegulatorContext context)
        {
            _objectSet = context.Set<T>();
            _context = context;
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _objectSet;
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
