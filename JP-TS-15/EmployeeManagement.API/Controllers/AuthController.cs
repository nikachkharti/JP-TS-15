using AutoMapper;
using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Models.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private APIResponse _response;

        public AuthController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _response = new();
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> Register([FromBody] UserRegistrationDTO model)
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

                if (await UserAlreadyExists(model.Email))
                {
                    _response.StatusCode = StatusCodes.Status400BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string>() { "User already registered." };
                    _response.Result = null;

                    return _response;
                }

                User newUser = _mapper.Map<User>(model);
                newUser.Role = "customer";

                if (newUser == null)
                {
                    _response.StatusCode = StatusCodes.Status404NotFound;
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string>() { "Content not found." };
                    _response.Result = null;

                    return _response;
                }

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                _response.StatusCode = StatusCodes.Status201Created;
                _response.IsSuccess = true;
                _response.ErrorMessage = null;
                _response.Result = newUser;
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


        [HttpPost("login")]
        public async Task<ActionResult<APIResponse>> Login([FromBody] UserRegistrationDTO model)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> UserAlreadyExists(string email) => await _context.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower());
    }
}
