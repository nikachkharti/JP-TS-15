using BankGPT.Library;
using BankGPT.Repository;
using BankGPT.Repository.Interfaces;
using System;
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
            const double transactionAmount = 100;

            CustomersModel sends = await _customersService.GetSingleCustomerAsync(20);
            List<AccountModel> sendsAccounts = await _accountService.GetAllAccountsOfCustomerAsync(20);

            CustomersModel recives = await _customersService.GetSingleCustomerAsync(17);
            List<AccountModel> recivesAccount = await _accountService.GetAllAccountsOfCustomerAsync(17);

            OperationModel sendsOperation = new()
            {
                AccountId = sendsAccounts[0].Id,
                Amount = transactionAmount,
                Currency = "USD",
                CustomerId = sends.Id,
                HappendAt = DateTime.Now,
                Type = "Personal transaction"
            };

            OperationModel recivesOperation = new()
            {
                AccountId = recivesAccount[0].Id,
                Amount = transactionAmount,
                Currency = "USD",
                CustomerId = recives.Id,
                HappendAt = DateTime.Now,
                Type = "Personal transaction"
            };

            sendsAccounts[0].Balance -= transactionAmount;
            recivesAccount[0].Balance += transactionAmount;

            await _accountService.UpdateAccountAsync(sendsAccounts[0]);
            await _accountService.UpdateAccountAsync(recivesAccount[0]);

            await _operationService.CreateOperationAsync(sendsOperation);
            await _operationService.CreateOperationAsync(recivesOperation);
        }

    }
}
