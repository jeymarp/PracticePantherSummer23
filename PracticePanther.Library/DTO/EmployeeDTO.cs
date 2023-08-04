using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.Library.Models;
using System;

namespace PracticePanther.Library.DTO
{
    public class EmployeeDTO
    {
        public EmployeeDTO()
        {
            Name = string.Empty;
        }

        public EmployeeDTO(Employee e)
        {
            this.Id = e.Id;
            this.Name = e.Name;
            this.Rate = e.Rate;
        }
        public string? Name { get; set; }

        public decimal? Rate { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Rate}";
        }
    }
}
