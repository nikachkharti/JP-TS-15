using BankGPT.Library;
using BankGPT.Repository.Interfaces;

namespace BankGPT.Repository
{
    public class AccountService : IAccountService
    {
        public Task CreateAccountAsync(AccountModel accountModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccountAsync(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountModel>> GetAllAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountModel>> GetAllAccountsOfCustomerAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccountAsync(AccountModel accountModel)
        {
            throw new NotImplementedException();
        }
    }
}
