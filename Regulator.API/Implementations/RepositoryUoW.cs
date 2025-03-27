using Regulator.API.Data;
using Regulator.API.Interfaces;
using Regulator.API.Models;

namespace Regulator.API.Implementations
{
    public class RepositoryUoW : IRepositoryUoW
    {
        private RegulatorContext _context;
        private bool disposed = false;
        public SqlRepository<OperationLog> OperationRepository { get; set; }
        public RepositoryUoW()
        {
            _context = new RegulatorContext();
            OperationRepository = new OperationRepository(_context);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
