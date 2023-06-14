using PracticePanther.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.Library.Services
{
    public class ClientService
    {
        private static ClientService? instance;
        private static object instanceLock = new object();
        public static ClientService Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ClientService();
                    }
                }
                return instance;
            }
        }

        private List<Client> clientsList;
        private ClientService()
        {
            clientsList = new List<Client>
            {
                new Client{Id = 1, Name = "Jhon Smith"},
                new Client{Id = 2, Name = "Bob Smith"},
                new Client{Id = 3, Name = "Sue Smith"}
            };
        }

        public List<Client> ClientsList
        {
            get { return clientsList; }
        }

        public List<Client> Search(string query)
        {
            return ClientsList.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }

        public Client? Get(int id)
        {
            return clientsList.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Client? client)
        {
            if (client != null)
            {
                clientsList.Add(client);
            }
        }

        public void Remove(int id)
        {
            var clientToRemove = Get(id);
            if (clientToRemove != null)
            {
                clientsList.Remove(clientToRemove);
            }
        }

        public void Remove(Client c)
        {
            Remove(c.Id);
        }

        public void Read()
        {
            if (!clientsList.Any())
            {
                System.Console.WriteLine("Currently, there are no registered clients");
            }
            else
            {
                foreach (var client in clientsList)
                {
                    System.Console.WriteLine("Client information: ");
                    System.Console.WriteLine($"ID: {client.Id}");
                    System.Console.WriteLine($"Name: {client.Name}");
                    System.Console.WriteLine($"Notes: {client.Notes}");
                    System.Console.WriteLine($"Open Date: {client.OpenDate}");
                    System.Console.WriteLine($"Client status: {client.IsActive}");
                }
            }
        }

    }
}
