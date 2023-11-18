using BankGPT.Library;
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

        [Fact]
        async Task Return_All_Accounts_From_DatabaseAsync()
        {
            var result = await _accountService.CreateAccountAsync(
                );
        }
    }
}
