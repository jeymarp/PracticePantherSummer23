using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;

namespace PracticePanther.Library.DataBase
{
    public static class FakeDataBase
    {
        private static List<Client> client = new List<Client>();
        private static List<Project> projects = new List<Project>();
        public static List<Employee> employees = new List<Employee>();
        public static List<Time> timeEntries = new List<Time>();
        public static List<Person> people = new List<Person>();
        public static List<Client> Client
        {
            get
            {
                return client;  
            }
        }
        public static List<Project> Projects
        {
            get
            {
                return projects;
            }
        }

        public static List<Employee> Employees
        {
            get
            {
                return employees;
            }
        }

        public static List<Time> Times
        {
            get
            {
                return timeEntries;
            }
        }

        public static List<Person> People

        {
            get
            {
                return people;
            }
        }
    }

}
