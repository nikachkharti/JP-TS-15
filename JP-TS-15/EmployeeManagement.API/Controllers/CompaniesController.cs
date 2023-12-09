using AutoMapper;
using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Models.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CompaniesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CompanyDTO>>> GetCompanies()
        {
            List<Company> companies = await _context.Companies.ToListAsync();
            List<CompanyDTO> result = _mapper.Map<List<CompanyDTO>>(companies);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CompanyDTO>> GetCompany([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            Company company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
            CompanyDTO result = _mapper.Map<CompanyDTO>(company);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> AddNewCompany([FromBody] CreateCompanyDTO model)
        {
            if (model == null)
                return BadRequest();

            Company newCompany = _mapper.Map<Company>(model);
            await _context.Companies.AddAsync(newCompany);
            await _context.SaveChangesAsync();

            return Created(string.Empty, model);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteCompany([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return NotFound();

            _context.Companies.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateCompany([FromBody] UpdateCompanyDTO model)
        {
            if (model.Id <= 0 || model == null)
                return BadRequest();

            Company result = _mapper.Map<Company>(model);

            _context.Companies.Update(result);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
