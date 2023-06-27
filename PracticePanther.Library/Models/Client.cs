using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.CLI.Models
{
    public class Client
    {
        public int Id { get; set; }   //Int property called Id

        public DateTime OpenDate { get; set; }   //DateTime property called OpenDate

        public DateTime ClosedDate { get; set; }  //DateTime property called ClosedDate

        public bool IsActive { get; set; }   // Boolean property called IsActive

        public string? Name { get; set; }   //String property called Name

        public string? Notes { get; set; }  //String property called Notes

        public List<Project>? Projects { get; set; }

        public int ProjectId { get; set; }
        public string Display
        {
            get
            {
                return ToString();
            }
        }

        public Client()
        {
            Name = string.Empty;
        }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
