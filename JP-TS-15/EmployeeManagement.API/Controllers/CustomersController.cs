using BankGPT.Library;
using BankGPT.Repository;
using BankGPT.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("[customers]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;
        public CustomersController()
        {
            _customersService = new CustomersService();
        }

        [HttpGet]
        public async Task<List<CustomersModel>> AllCustomers()
        {
            var result = await _customersService.GetAllCustomersAsync();
            return result;
        }
    }
}
