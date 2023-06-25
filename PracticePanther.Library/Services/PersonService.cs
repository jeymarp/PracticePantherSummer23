using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.Library.Services
{
  /* public class PersonService
    {
        public List<Person> People { 
            get {
                return people;
            } 
        }

        private List<Person> people;

        private static PersonService? instancep;

        public static PersonService CurrentP
        {
            get
            {
                if (instancep == null)
                {
                    instancep = new PersonService();
                }
                return instancep;
            }
        }
        private PersonService()
        {
            people = new List<Client>
            {
                new Person{ Id = 1, Name = "Person 1"},
                new Person{ Id = 2, Name = "Person 2"},
                new Person{ Id = 3, Name = "Person 3"},
                new Person{ Id = 4, Name = "Person 4"},
                new Person{ Id = 5, Name = "Person 5"},
                new Person{ Id = 6, Name = "Person 6"}
            };
        }

        public void Delete(int id)
        {
            var personToDelete = People.FirstOrDefault(p => p.Id == id);
            if(personToDelete != null)
            {
                People.Remove(PersonToDelete);
            }
        }

        public void Add(Person p)
        {
            if(c.Id == 0)
            {
                //add
                c.Id = LastId + 1;
            }

            People.Add(p);
        }

        private int LastId
        {
            get
            {
                return People.Any() ? People.Select(p => p.Id).Max() : 0;
            }
        }
    }
  */
  
}
