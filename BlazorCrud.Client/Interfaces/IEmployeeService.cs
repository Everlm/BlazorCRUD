using BlazorCrud.Shared.Dtos.Employee;

namespace BlazorCrud.Client.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> EmployeesList();
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<int> Register(EmployeeDto requestDto);
        Task<int> EditEmployee(EmployeeDto requestDto, int id);
        Task<bool> DeleteEmployee(int id);
    }
}
