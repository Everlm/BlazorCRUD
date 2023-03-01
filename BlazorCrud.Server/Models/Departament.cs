using System;
using System.Collections.Generic;

namespace BlazorCrud.Server.Models
{
    public partial class Departament
    {
        public Departament()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartamentId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
