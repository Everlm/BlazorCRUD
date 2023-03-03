using BlazorCrud.Shared.Dtos.Departament.Response;
using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Shared.Dtos.Employee
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Departament { get; set; }
        public int DepartamentId { get; set; }
        public int Salary { get; set; }
        public DateTime ContractDate { get; set; }
    }
}
