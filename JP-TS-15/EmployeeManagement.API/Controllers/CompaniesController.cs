using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Company>> GetCompanies()
        {
            var result = _context.Companies.ToList();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Company> GetCompany([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = _context.Companies.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult AddNewCompany([FromBody] Company model)
        {
            if (model == null)
                return BadRequest();

            _context.Companies.Add(model);
            _context.SaveChanges();

            return Created(string.Empty, model);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteCompany([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = _context.Companies.FirstOrDefault(x => x.Id == id);

            if (result == null)
                return NotFound();

            _context.Companies.Remove(result);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult UpdateCompany([FromBody] Company model)
        {
            if (model.Id <= 0 || model == null)
                return BadRequest();

            _context.Companies.Update(model);
            _context.SaveChanges();

            return Ok();
        }
    }
}
