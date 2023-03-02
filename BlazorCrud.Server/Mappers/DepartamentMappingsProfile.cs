using BlazorCrud.Server.Models;
using AutoMapper;
using BlazorCrud.Shared.Dtos.Departament.Response;

namespace BlazorCrud.Server.Mappers
{
    public class DepartamentMappingsProfile : Profile
    {
        public DepartamentMappingsProfile()
        {
            CreateMap<Departament, DepartamentResponseDto>();
        }
    }
}
