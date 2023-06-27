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
                new Client{ Id = 6, Name = "home"}
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

        public void AddOrUpdate(Client? c)
        {
            var isAdd = false;
            if (c?.Id == 0)
            {
                //add
                isAdd = true;
                c.Id = LastId + 1;

            }

            if (isAdd)
            {
                Clients.Add(c);
            }
        }

        public Client? Get(int id)
        {
            return Clients.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Client> Search(string query)
        {
            return Clients
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }
        private int LastId
        {
            get
            {
                return Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
            }
        }

      
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

        /*
public void Edit(Client? updatedClient)
{
    var clientToUpdate = Clients.FirstOrDefault(c => c.Id == updatedClient?.Id);
    if (clientToUpdate != null)
    {
        clientToUpdate.Name = updatedClient?.Name;
        clientToUpdate.Notes = updatedClient.Notes;
        clientToUpdate.OpenDate = updatedClient.OpenDate;
        clientToUpdate.ClosedDate = updatedClient.ClosedDate;
    }
}
}*/
    }
}
