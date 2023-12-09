using AutoMapper;
using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeeDTO>>> GetEmployees()
        {
            List<Employee> employees = await _context.Employees.ToListAsync();
            List<EmployeeDTO> result = _mapper.Map<List<EmployeeDTO>>(employees);

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Employee>> GetEmployee([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            Employee employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            EmployeeDTO result = _mapper.Map<EmployeeDTO>(employee);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AddNewEmployee([FromBody] CreateEmployeeDTO model)
        {
            if (model == null)
                return BadRequest();

            Employee newEmployee = _mapper.Map<Employee>(model);

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

            return Created(string.Empty, model);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateEmployee([FromBody] UpdateEmployeeDTO model)
        {
            if (model.Id <= 0 || model == null)
                return BadRequest();

            Employee result = _mapper.Map<Employee>(model);

            _context.Employees.Update(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<Employee>> DeleteEmployee([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = _context.Employees.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            _context.Employees.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
