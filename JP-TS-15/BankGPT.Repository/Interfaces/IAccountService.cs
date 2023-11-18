using BankGPT.Library;

namespace BankGPT.Repository.Interfaces
{
    public interface IAccountService
    {
        Task CreateAccountAsync(AccountModel accountModel);
        Task<List<AccountModel>> GetAllAccountsAsync();
        Task UpdateAccountAsync(AccountModel accountModel);
        Task DeleteAccountAsync(int accountId);
        Task<List<AccountModel>> GetAllAccountsOfCustomerAsync();
    }
}
