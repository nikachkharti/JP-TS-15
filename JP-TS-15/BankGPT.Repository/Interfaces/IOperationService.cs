using BankGPT.Library;

namespace BankGPT.Repository.Interfaces
{
    public interface IOperationService
    {
        Task<List<OperationModel>> GetAllOperationsAsync();
        Task<OperationModel> GetAllOperationsForCustomerAsync(int customerId);
        Task<OperationModel> GetAllOperationsForAccountAsync(int accountId);
        Task CreateOperationAsync(OperationModel model);
        Task DeleteOperationAsync(int operationId);
    }
}
