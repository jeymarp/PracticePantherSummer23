using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.Library.DataBase;

namespace PracticePanther.CLI.Models
{
    public class Project
    {
        public int Id { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime ClosedDate { get; set; }

        public bool IsActive { get; set; }

        public string? ShortName { get; set; }

        public string? LongName { get; set; }

        public int ClientId { get; set; }

        public List<Client>? Roster { get; set; }   //list of clients

        public Client? Client { get; set; }
        public List<Employee>? employees { get; set; }
        public override string ToString()
        {
            return $"{Id}. {ShortName}";
        }
    }
}
