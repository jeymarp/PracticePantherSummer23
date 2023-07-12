/***************************************************************************************************
* Name: Jeyma Rodriguez
* FSUID: jdr21d
* COP4870 
* Professor: Christopher Mills
* Assignment 3
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticePanther.Library.Models
{
    public class Bill
    {
        public decimal TotalAmount { get; set; }
        public DateTime DueDate { get; set; }

        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public object? ProjectId { get; internal set; }
        public object? ClientId { get; internal set; }
        public IEnumerable<object>? Time { get; set; }

        public override string ToString()
        {
            return $"{TotalAmount}";
        }
    }
}
