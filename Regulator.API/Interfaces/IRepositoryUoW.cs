using Regulator.API.Implementations;
using Regulator.API.Models;

namespace Regulator.API.Interfaces
{
    public interface IRepositoryUoW : IDisposable
    {
        public SqlRepository<OperationLog> OperationRepository { get; }
    }
}
