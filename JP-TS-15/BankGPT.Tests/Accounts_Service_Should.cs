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
    }
}
