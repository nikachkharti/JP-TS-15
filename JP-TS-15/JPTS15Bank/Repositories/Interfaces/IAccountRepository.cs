using JPTS15Bank.Models;

namespace JPTS15Bank.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        void AddAccount(Account model);
        Account GetAccountById(int id);
        List<Account> GetAllAccounts();
        List<Account> GetAccountsByCustomerId(int customerId);
    }
}
