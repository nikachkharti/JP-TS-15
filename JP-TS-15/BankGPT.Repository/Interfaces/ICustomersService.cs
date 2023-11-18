using BankGPT.Library;

namespace BankGPT.Repository.Interfaces
{
    public interface ICustomersService
    {
        Task<List<CustomersModel>> GetAllCustomersAsync();
        Task CreateCustomerAsync(CustomersModel customersModel);
        Task UpdateCustomerAsync(CustomersModel customersModel);
        Task DeleteCustomerAsync(int id);
        Task<CustomersModel> GetSingleCustomerAsync(int id);
    }
}
