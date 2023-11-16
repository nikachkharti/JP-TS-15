using BankGPT.Library;

namespace BankGPT.Repository.Interfaces
{
    public interface ICustomersService
    {
        Task<List<CustomersModel>> GetAllCustomers();
        void CreateCustomer(CustomersModel customersModel);
        void UpdateCustomer(CustomersModel customersModel);
        void DeleteCustomer(int id);
    }
}
