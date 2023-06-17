using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticePanther.Library.Services
{/*
    public class PersonService
    {
        private static ClientService? instancep;
        private static object instanceLock = new object();
        public static ClientService Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instancep == null)
                    {
                        instancep = new ClientService();
                    }
                }
                return instancep;
            }
        }
        private List<Client> clientsList;
        private PersonService()
        {
            clientsList = new List<Client>();
        }

        public List<Client> ClientList
        {
            get { return clientsList; }
        }

        public Client? GetById(int id)
        {
            return clientsList.FirstOrDefault(c => c.Id == id);
        }

    }*/
}
