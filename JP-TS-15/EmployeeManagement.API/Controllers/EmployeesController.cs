using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Models.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<EmployeeDTO>> GetEmployees()
        {

            List<Employee> employees = _context.Employees.ToList();

            List<EmployeeDTO> result = employees.Select(x => new EmployeeDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<EmployeeDTO> GetEmployee([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            Employee employee = _context.Employees.FirstOrDefault(x => x.Id == id);

            EmployeeDTO result = new()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName
            };

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult AddNewEmployee([FromBody] AddEmployeeDTO model)
        {
            if (model == null)
                return BadRequest();

            Employee newEmployee = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            _context.Employees.Add(newEmployee);
            _context.SaveChanges();

            return Created(string.Empty, model);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult UpdateEmployee([FromBody] UpdateEmployeeDTO model)
        {
            if (model.Id <= 0 || model == null)
                return BadRequest();


            Employee result = new()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            _context.Employees.Update(result);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Employee> DeleteEmployee([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = _context.Employees.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            _context.Employees.Remove(result);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
