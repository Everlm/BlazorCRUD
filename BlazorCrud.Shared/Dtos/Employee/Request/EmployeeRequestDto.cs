namespace BlazorCrud.Shared.Dtos.Employee.Request
{
    public class EmployeeRequestDto
    {
        public string FullName { get; set; } = null!;
        public int DepartamentId { get; set; }
        public int Salary { get; set; }
        public DateTime ContractDate { get; set; }
    }
}
