using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Shared.Dtos.Employee.Response
{
    public class EmployeeResponseDto
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Is required")]
        public string FullName { get; set; } = null!;
        public string? Departament { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Is required")]
        public int Salary { get; set; }
        public DateTime ContractDate { get; set; }

       
    }
}
