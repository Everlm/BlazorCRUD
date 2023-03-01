using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Shared.Dtos
{
    public class EmployeeDto
    {

        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Is required")]
        public string FullName { get; set; } = null!;

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Is required")]
        public int DepartamentId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Is required")]
        public int Salary { get; set; }

        public DateTime ContractDate { get; set; }

        public DepartamentDto? Departament { get; set; }
    }
}
