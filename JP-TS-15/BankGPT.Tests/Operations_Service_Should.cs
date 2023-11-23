using BankGPT.Library;
using BankGPT.Repository;
using BankGPT.Repository.Interfaces;
using System.Threading.Tasks;
using Xunit;
namespace BankGPT.Tests
{
    public class Operations_Service_Should
    {
        private readonly IOperationService _operationService;

        public Operations_Service_Should()
        {
            _operationService = new OperationService();
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
    }
}
