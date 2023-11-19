using BankGPT.Library;
using BankGPT.Repository.Interfaces;

namespace BankGPT.Repository
{
    public class OperationService : IOperationService
    {
        public Task CreateOperationAsync(OperationModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOperationAsync(int operationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OperationModel>> GetAllOperationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<OperationModel>> GetAllOperationsForAccountAsync(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<OperationModel>> GetAllOperationsForCustomerAsync(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
