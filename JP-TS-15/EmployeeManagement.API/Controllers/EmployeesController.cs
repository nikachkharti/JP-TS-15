using EmployeeManagement.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetEmployees()
        {
            var result = EmployeeStore.Employees;
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Employee> GetEmployee(int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = EmployeeStore.Employees.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult AddNewEmployee(Employee model)
        {
            if (model == null)
                return BadRequest();

            var newId = EmployeeStore.Employees.Max(x => x.Id) + 1;
            model.Id = newId;

            EmployeeStore.Employees.Add(model);
            return Created(string.Empty, model);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult UpdateEmployee(int id, Employee model)
        {
            if (id <= 0 || model.Id != id)
                return BadRequest();

            var result = EmployeeStore.Employees.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            result.FirstName = model.FirstName;
            result.LastName = model.LastName;

            return Ok();
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = EmployeeStore.Employees.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            EmployeeStore.Employees.Remove(result);

            return NoContent();
        }

    }
}
