using BankGPT.Library;
using BankGPT.Repository;
using BankGPT.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace BankGPT.Tests
{
    public class Operations_Service_Should
    {
        private readonly IOperationService _operationService;
        private readonly IAccountService _accountService;
        private readonly ICustomersService _customersService;

        public Operations_Service_Should()
        {
            _operationService = new OperationService();
            _accountService = new AccountService();
            _customersService = new CustomersService();
        }
        [Fact]
        async void Delete_Operation_In_Database()
        {
            await _operationService.DeleteOperationAsync(1);
        }

        [Fact]
        async Task Return_All_Operation_From_DatabaseAsync()
        {
            var result = await _operationService.GetAllOperationsAsync();
        }

        [Fact]
        async void Return_All_Operation_For_AccountAsync()
        {
            var result = await _operationService.GetAllOperationsForAccountAsync(1);
        }

        [Fact]
        async void Return_All_Operation_For_CustomerAsync()
        {
            var result = await _operationService.GetAllOperationsForCustomerAsync(1);
        }

        [Fact]
        public async void Create_New_Operation()
        {
            CustomersModel sends = await _customersService.GetSingleCustomerAsync(20);
            List<AccountModel> sendsAccounts = await _accountService.GetAllAccountsOfCustomerAsync(20);

            //TODO...CONTINUE HERE

            //var result = await _operationService.CreateOperationAsync();
        }

    }
}
