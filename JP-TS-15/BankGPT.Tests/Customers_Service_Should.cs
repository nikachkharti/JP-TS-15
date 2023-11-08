using BankGPT.Repository;
using Xunit;

namespace Student.Service.Tests
{
    public class Student_Service_Should
    {
        [Fact]
        void Return_All_Customers_From_Database()
        {
            CustomersService customersService = new();
            var result = customersService.GetAllCustomers();
        }
    }
}
