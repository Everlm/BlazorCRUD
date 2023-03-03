using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Entities
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; } = null!;
        public int DepartamentId { get; set; }
        public int Salary { get; set; }
        public DateTime ContractDate { get; set; }

        public virtual Departament Departament { get; set; } = null!;
    }
}
