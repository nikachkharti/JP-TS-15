using BankGPT.Library;
using BankGPT.Repository;
using Xunit;

namespace Student.Service.Tests
{
    public class Student_Service_Should
    {
        private readonly CustomersService _customerService;
        public Student_Service_Should()
        {
            _customerService = new CustomersService();
        }

        [Fact]
        void Return_All_Customers_From_Database()
        {
            var result = _customerService.GetAllCustomers();
        }


        [Fact]
        void Return_Single_Customer_From_Database()
        {
            var result = _customerService.GetSingleCustomer(1);
        }

        [Fact]
        void Create_Customer_In_Database()
        {
            CustomersModel newCustomer = new()
            {
                FullName = "Kvachi Kvachantiradze",
                Email = "Kvachi@gmail.com",
                IdentityNumber = "01024085083",
                PhoneNumber = "555337681",
                Type = "Phyisical"
            };

            _customerService.CreateCustomer(newCustomer);
        }

        [Fact]
        void Delete_Customer_In_Database()
        {
            _customerService.DeleteCustomer(22);
        }

        [Fact]
        void Update_Customer_In_Database()
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
            _customerService.UpdateCustomer(newCustomer);
        }

    }
}
