using PracticePanther.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.Library.Models
{
    public class Employee
    {
        public Employee() 
        {
            Name = string.Empty;
        }
        public string? Name { get; set; }

        public decimal? Rate { get; set; }

        public int Id { get; set; }

        public Employee(EmployeeDTO dto)
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
        }
        public string? Property1 { get; set; }
        public string? Property2 { get; set; }
        public string? Property3 { get; set; }
        public string? Property4 { get; set; }
        public string? Property5 { get; set; }
        public string? Property6 { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name} {Rate}";
        }
    }
}
