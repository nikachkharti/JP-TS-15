using BankGPT.Library;

namespace BankGPT.Repository.Interfaces
{
    public interface IOperationService
    {
        Task<List<OperationModel>> GetAllOperationsAsync();
        Task<List<OperationModel>> GetAllOperationsForCustomerAsync(int customerId);
        Task<List<OperationModel>> GetAllOperationsForAccountAsync(int accountId);
        Task CreateOperationAsync(OperationModel model);
        Task DeleteOperationAsync(int operationId);
    }
}
