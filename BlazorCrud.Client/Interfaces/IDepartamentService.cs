using BlazorCrud.Shared.Dtos.Departament.Response;

namespace BlazorCrud.Client.Interfaces
{
    public interface IDepartamentService
    {
        Task<List<DepartamentResponseDto>> DepartamentList();
    }
}
