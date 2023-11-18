using BankGPT.Repository;
using BankGPT.Repository.Interfaces;

namespace BankGPT.Tests
{
    public class Accounts_Service_Should
    {
        private readonly IAccountService _accountService;
        public Accounts_Service_Should()
        {
            _accountService = new AccountService();
        }
    }
}
