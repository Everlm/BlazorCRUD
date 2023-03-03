using BlazorCrud.Client.Interfaces;
using BlazorCrud.Shared.Commons.Base;
using BlazorCrud.Shared.Dtos.Employee;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeDto>> EmployeesList()
        {
            var response = await _httpClient.GetFromJsonAsync<BaseResponse<List<EmployeeDto>>>("api/Employee/ListEmployees");

            if (response!.IsSuccess)
                return response.Data!;
            else
                throw new Exception(response.Message);
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<BaseResponse<EmployeeDto>>($"api/Employee/{id}");

            if (response!.IsSuccess)
                return response.Data!;
            else
                throw new Exception(response.Message);
        }

        public async Task<int> Register(EmployeeDto requestDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Employee/Register", requestDto);
            var content = await response.Content.ReadFromJsonAsync<BaseResponse<int>>();

            if (content!.IsSuccess)
                return content.Data!;
            else
                throw new Exception(content.Message);
        }
        public async Task<int> EditEmployee(EmployeeDto requestDto, int id)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Employee/Edit/{id}", requestDto);
            var content = await response.Content.ReadFromJsonAsync<BaseResponse<int>>();

            if (content!.IsSuccess)
                return content.Data!;
            else
                throw new Exception(content.Message);
        }
        public async Task<bool> DeleteEmployee(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Employee/Delete/{id}");
            var content = await response.Content.ReadFromJsonAsync<BaseResponse<int>>();

            if (content!.IsSuccess)
                return content.IsSuccess!;
            else
                throw new Exception(content.Message);
        }
    }
}
