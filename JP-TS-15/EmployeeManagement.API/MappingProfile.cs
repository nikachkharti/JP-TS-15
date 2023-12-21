using AutoMapper;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Models.DTOS;

namespace EmployeeManagement.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDTO>();
            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<UpdateCompanyDTO, Company>();

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();

            CreateMap<UserRegistrationDTO, User>();
        }
    }
}
