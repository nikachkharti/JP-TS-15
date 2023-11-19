using BankGPT.Library;
using BankGPT.Repository;
using BankGPT.Repository.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace BankGPT.Tests
{
    public class Customers_Service_Should
    {
        private readonly ICustomersService _customerService;
        public Customers_Service_Should()
        {
            _customerService = new CustomersService();
        }

        [Fact]
        async Task Return_All_Customers_From_DatabaseAsync()
        {
            var result = await _customerService.GetAllCustomersAsync();
        }


        [Fact]
        async void Return_Single_Customer_From_Database()
        {
            var result = await _customerService.GetSingleCustomerAsync(1);
        }

        [Fact]
        async void Create_Customer_In_Database()
        {
            CustomersModel newCustomer = new()
            {
                FullName = "Kvachi Kvachantiradze",
                Email = "Kvachi@gmail.com",
                IdentityNumber = "01024085083",
                PhoneNumber = "555337681",
                Type = "Phyisical"
            };

            await _customerService.CreateCustomerAsync(newCustomer);
        }

        [Fact]
        async void Delete_Customer_In_Database()
        {
            await _customerService.DeleteCustomerAsync(22);
        }

        [Fact]
        async void Update_Customer_In_Database()
        {
            CustomersModel newCustomer = new()
            {
                Id = 21,
                FullName = "Kvachi Kvachantiradze",
                Email = "Kvachi@gmail.com",
                IdentityNumber = "01024085083",
                PhoneNumber = "555337681",
                Type = "Phyisical"
            };

            await _customerService.UpdateCustomerAsync(newCustomer);
        }

    }
}
