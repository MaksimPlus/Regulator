using Regulator.API.Interfaces;
using Regulator.API.Models;

namespace Regulator.API.Implementations
{
    public class CalculateService : ICalculate
    {
        public CalculateService()
        {
            
        }
        public double CalculateSum(double a, double b)
        {
            double result;
            string resultMessage = "Ok";
            var operationLog = new OperationLog
            {
                FirstValue = a,
                SecondValue = b
            };
            using (var uow = new RepositoryUoW())
            {
                try
                {
                    result = a + b;                    
                }
                catch (OverflowException e)
                {
                    result = 0;
                    resultMessage = e.Message;
                }

                operationLog.Result = result;
                operationLog.ResultMessage = resultMessage;
                uow.OperationRepository.Add(operationLog);
                uow.Commit();
            }
            return result;
        }
        public IReadOnlyList<OperationLog> GetOperationLogs()
        {
            using (var uow = new RepositoryUoW())
            {
                return uow.OperationRepository.GetAll().ToList();
            }
        }
    }
}
