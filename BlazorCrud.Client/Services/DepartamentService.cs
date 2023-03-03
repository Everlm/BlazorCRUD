using BlazorCrud.Client.Interfaces;
using BlazorCrud.Shared.Commons.Base;
using BlazorCrud.Shared.Dtos.Departament.Response;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class DepartamentService : IDepartamentService
    {
        private readonly HttpClient _httpClient;
        public DepartamentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<DepartamentResponseDto>> DepartamentList()
        {
            var response = await _httpClient.GetFromJsonAsync<BaseResponse<List<DepartamentResponseDto>>>("api/Departament/ListDepartaments");

            if (response!.IsSuccess)
                return response.Data!;
            else
                throw new Exception(response.Message);

        }
    }
}
