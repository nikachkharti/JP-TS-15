using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Models.DTOS;
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
        public ActionResult<List<CompanyDTO>> GetCompanies()
        {
            List<Company> companies = _context.Companies.ToList();

            //TODO Implement automapper logic here...
            List<CompanyDTO> result = companies.Select(x => new CompanyDTO
            {
                Id = x.Id,
                Title = x.Title,
                CreateDate = x.CreateDate
            }).ToList();

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CompanyDTO> GetCompany([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            Company company = _context.Companies.FirstOrDefault(x => x.Id == id);

            //TODO Implement automapper logic here...
            CompanyDTO result = new()
            {
                Id = company.Id,
                Title = company.Title,
                CreateDate = company.CreateDate
            };

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult AddNewCompany([FromBody] CreateCompanyDTO model)
        {
            if (model == null)
                return BadRequest();

            //TODO Implement automapper logic here...
            Company newCompany = new()
            {
                Title = model.Title,
                CreateDate = model.CreateDate
            };

            _context.Companies.Add(newCompany);
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
        public ActionResult UpdateCompany([FromBody] UpdateCompanyDTO model)
        {
            if (model.Id <= 0 || model == null)
                return BadRequest();


            //TODO Implement automapper logic here...
            Company result = new()
            {
                Id = model.Id,
                Title = model.Title,
                CreateDate = model.CreateDate
            };

            _context.Companies.Update(result);
            _context.SaveChanges();

            return Ok();
        }
    }
}
