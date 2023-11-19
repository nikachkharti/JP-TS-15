using BankGPT.Library;
using BankGPT.Repository;
using BankGPT.Repository.Interfaces;
using System.Threading.Tasks;
using Xunit;
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
        async void Create_Account_In_Database()
        {
            AccountModel newAccount = new()
            {
                Iban = "GE2842TEU24582",
                Currency = "Gel",
                Balance = 218.15,
                CustomerId = 1,
                Name = "For Business"
            };

            await _accountService.CreateAccountAsync(newAccount);
        }

        [Fact]
        async void Delete_Account_In_Database()
        {
            await _accountService.DeleteAccountAsync(10);
        }

        [Fact]
        async Task Return_All_Accounts_From_DatabaseAsync()
        {
            var result = await _accountService.GetAllAccountsAsync();
        }

        [Fact]
        async void Return_Single_Account_From_Database()
        {
            var result = await _accountService.GetSingleAccountAsync(1);
        }

        [Fact]
        async void Update_Account_In_Database()
        {
            AccountModel newAccount = new()
            {
                Id = 2,
                Iban = "GE381002TBDJK10",
                Currency = "USD",
                Balance = 597.34,
                CustomerId = 2,
                Name = "For Education"
            };

            await _accountService.UpdateAccountAsync(newAccount);
        }
    }
}
