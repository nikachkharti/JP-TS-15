using EmployeeManagement.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        public List<Employee> GetEmployees()
        {
            var allEmployees = EmployeeStore.GetAllEmployees();
            return allEmployees;
        }

        [HttpGet]
        public Employee GetEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
