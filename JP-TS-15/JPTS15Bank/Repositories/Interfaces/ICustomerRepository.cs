using JPTS15Bank.Models;

namespace JPTS15Bank.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer model);
        Customer GetCustomerById(int id);
    }
}
