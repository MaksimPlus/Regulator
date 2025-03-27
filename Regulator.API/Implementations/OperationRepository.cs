using Regulator.API.Data;
using Regulator.API.Models;

namespace Regulator.API.Implementations
{
    public class OperationRepository : SqlRepository<OperationLog>
    {
        public OperationRepository(RegulatorContext context) : base(context)
        {
            
        }
    }
}
