using PracticePanther.CLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.Library.DataBase;

namespace PracticePanther.Library.Services
{
    public class ClientService
    {
        public List<Client> Clients
        {
            get
            {
                return clients;
            }
        }

        private List<Client> clients;

        private static ClientService? instance;
        public static ClientService Current {
            get
            {
                if (instance == null)
                {
                    instance = new ClientService();
                }
                
               return instance;
            }
        }

        private ClientService()
        {
            clients = new List<Client>
            {
               new Client{ Id = 1, Name = "Client 1"},
                new Client{ Id = 2, Name = "Client 2"},
                new Client{ Id = 3, Name = "Client 3"},
                new Client{ Id = 4, Name = "Client 4"},
                new Client{ Id = 5, Name = "Client 5"},
                new Client{ Id = 6, Name = "Client 6"}
            };
        }

        public void Delete(int id)
        {
            var clientToDelete = Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                Clients.Remove(clientToDelete);
            }
        }

        public void Add(Client? c)
        {
            if (c.Id == 0)
            {
                //add
                c.Id = LastId + 1;
            }

            Clients.Add(c);
        }

        private int LastId
        {
            get
            {
                return Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
            }
        }

        public Client? Get(int id)
        {
            return clients.FirstOrDefault(c => c.Id == id);
        }
        public List<Client> Search(string query)
       {
           return Clients.Where(c => c.Name.ToUpper().Contains(query.ToUpper())).ToList();
       }

        /*
      public void Remove(int id)
      {
          var clientToRemove = Get(id);
          if (clientToRemove != null)
          {
              ClientsList.Remove(clientToRemove);
          }
      }

      public void Remove(Client c)
      {
          Remove(c.Id);
      }
       }*/
        public void Read()
         {
             if (!clients.Any())
             {
                 System.Console.WriteLine("Currently, there are no registered clients");
             }
             else
             {
                 foreach (var client in clients)
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
