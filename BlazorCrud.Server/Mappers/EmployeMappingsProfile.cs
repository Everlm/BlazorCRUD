using AutoMapper;
using BlazorCrud.Server.Models;
using BlazorCrud.Shared.Dtos.Employee.Request;
using BlazorCrud.Shared.Dtos.Employee.Response;

namespace BlazorCrud.Server.Mappers
{
    public class EmployeMappingsProfile : Profile
    {
        public EmployeMappingsProfile()
        {
            CreateMap<Employee, EmployeeResponseDto>()
             .ForMember(x => x.Departament, x => x.MapFrom(y => y.Departament.Name))
             .ReverseMap();

            CreateMap<EmployeeRequestDto, Employee>();
        }
    }
}
