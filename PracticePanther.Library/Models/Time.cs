using PracticePanther.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.Library.Models
{
    public class Time
    {
        public DateTime Date { get; set; }

        public string? Narrative { get; set; }

        public decimal Hours { get; set; }

        public int ProjectId { get; set; }

        public int EmployeeId { get; set; }

        public int TimeId { get; set; }
       
        //public override string ToString()
        //{
        //    return $"{Date}";
        //}

        public Time()
        {
            TimeId = 0;
            ProjectId = 0;
            EmployeeId = 0;
            Hours = 0;
            Date = DateTime.MinValue;
            Narrative = string.Empty;
        }

    }
     
}
