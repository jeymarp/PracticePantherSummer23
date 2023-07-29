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
        public int BillId { get; set; }
        public int ProjectId { get; set; }
        public int ClientId { get; set; }
        public List<Time>? Time { get; set; }
        public Bill()
        {
            Time = new List<Time>();
        }
        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public override string ToString()
        {
            return $"Due Date: {DueDate}, Total Amount: {TotalAmount:C}";
        }
    }
}
