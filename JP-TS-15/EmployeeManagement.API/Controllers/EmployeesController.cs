using EmployeeManagement.API.Data;
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
        public ActionResult<List<Employee>> GetEmployees()
        {
            var result = _context.Employees.ToList();
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

            var result = _context.Employees.FirstOrDefault(x => x.Id == id);

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

            _context.Employees.Add(model);
            _context.SaveChanges();

            return Created(string.Empty, model);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult UpdateEmployee(Employee model)
        {
            if (model.Id <= 0 || model == null)
                return BadRequest();

            _context.Employees.Update(model);
            _context.SaveChanges();

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

            var result = _context.Employees.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            _context.Employees.Remove(result);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
