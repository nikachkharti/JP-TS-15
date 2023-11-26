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
            var result = EmployeeStore.Employees;
            return result;
        }

        [HttpGet("{id:int}")]
        public Employee GetEmployee(int id)
        {
            var result = EmployeeStore.Employees.FirstOrDefault(x => x.Id == id);
            return result;
        }

        [HttpPost]
        public void AddNewEmployee(Employee model)
        {
            EmployeeStore.Employees.Add(model);
        }
    }
}
