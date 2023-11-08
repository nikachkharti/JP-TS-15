using BankGPT.Library;

namespace BankGPT.Repository.Interfaces
{
    public interface ICustomersService
    {
        List<CustomersModel> GetAllCustomers();
    }
}
