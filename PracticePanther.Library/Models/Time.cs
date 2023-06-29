﻿using System;
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

        public override string ToString()
        {
            return $"{Date}, {Hours}";
        }
    }
     
}
