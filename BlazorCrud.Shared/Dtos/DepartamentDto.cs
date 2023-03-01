using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.Shared.Dtos
{
    public class DepartamentDto
    {
        public int DepartamentId { get; set; }
        public string Name { get; set; } = null!;
    }
}
