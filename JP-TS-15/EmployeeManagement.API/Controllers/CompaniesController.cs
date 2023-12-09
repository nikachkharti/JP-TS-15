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
        private APIResponse _response;

        public CompaniesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetCompanies()
        {
            try
            {
                List<Company> companies = await _context.Companies.ToListAsync();
                List<CompanyDTO> result = _mapper.Map<List<CompanyDTO>>(companies);

                if (result == null)
                {
                    _response.StatusCode = StatusCodes.Status404NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string>() { "Content not found." };
                    _response.Result = null;

                    return _response;
                }

                _response.StatusCode = StatusCodes.Status200OK;
                _response.IsSuccess = true;
                _response.ErrorMessage = null;
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.StatusCode = StatusCodes.Status500InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
                _response.Result = null;
            }

            return _response;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetCompany([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = StatusCodes.Status400BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string>() { "Bad request." };
                    _response.Result = null;

                    return _response;
                }

                Company company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
                CompanyDTO result = _mapper.Map<CompanyDTO>(company);

                if (result == null)
                {
                    _response.StatusCode = StatusCodes.Status404NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string>() { "Content not found." };
                    _response.Result = null;

                    return _response;
                }

                _response.StatusCode = StatusCodes.Status200OK;
                _response.IsSuccess = true;
                _response.ErrorMessage = null;
                _response.Result = result;

            }
            catch (Exception ex)
            {
                _response.StatusCode = StatusCodes.Status500InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
                _response.Result = null;
            }

            return _response;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> AddNewCompany([FromBody] CreateCompanyDTO model)
        {
            try
            {
                if (model == null)
                {
                    _response.StatusCode = StatusCodes.Status400BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string>() { "Bad request." };
                    _response.Result = null;

                    return _response;
                }

                Company newCompany = _mapper.Map<Company>(model);

                if (newCompany == null)
                {
                    _response.StatusCode = StatusCodes.Status404NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string>() { "Content not found." };
                    _response.Result = null;

                    return _response;
                }

                await _context.Companies.AddAsync(newCompany);
                await _context.SaveChangesAsync();

                _response.StatusCode = StatusCodes.Status201Created;
                _response.IsSuccess = true;
                _response.ErrorMessage = null;
                _response.Result = newCompany;
            }
            catch (Exception ex)
            {
                _response.StatusCode = StatusCodes.Status500InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
                _response.Result = null;
            }

            return _response;
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteCompany([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = StatusCodes.Status400BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string>() { "Bad request." };
                    _response.Result = null;

                    return _response;
                }

                var result = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                {
                    _response.StatusCode = StatusCodes.Status404NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string>() { "Content not found." };
                    _response.Result = null;

                    return _response;
                }

                _context.Companies.Remove(result);
                await _context.SaveChangesAsync();

                _response.StatusCode = StatusCodes.Status201Created;
                _response.IsSuccess = true;
                _response.ErrorMessage = null;
                _response.Result = result;

            }
            catch (Exception ex)
            {
                _response.StatusCode = StatusCodes.Status500InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
                _response.Result = null;
            }

            return _response;
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateCompany([FromBody] UpdateCompanyDTO model)
        {
            try
            {
                if (model.Id <= 0 || model == null)
                {
                    _response.StatusCode = StatusCodes.Status400BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string>() { "Bad request." };
                    _response.Result = null;

                    return _response;
                }

                Company result = _mapper.Map<Company>(model);

                if (result == null)
                {
                    _response.StatusCode = StatusCodes.Status404NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string>() { "Content not found." };
                    _response.Result = null;

                    return _response;
                }

                _context.Companies.Update(result);
                await _context.SaveChangesAsync();

                _response.StatusCode = StatusCodes.Status200OK;
                _response.IsSuccess = true;
                _response.ErrorMessage = null;
                _response.Result = result;

            }
            catch (Exception ex)
            {
                _response.StatusCode = StatusCodes.Status500InternalServerError;
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.Message };
                _response.Result = null;
            }

            return _response;
        }
    }
}
