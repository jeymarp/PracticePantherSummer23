using PracticePanther.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.Library.Models;
using System.Runtime.CompilerServices;
using PracticePanther.CLI.Models;

namespace PracticePanther.MAUI.ViewModels
{
    public class PersonDetailViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public PersonDetailViewModel(int id = 0)
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }

        public void LoadById(int id)
        {
            if(id == 0) { return; }
            var person = ClientService.Current.Get(id) as Client;
            if (person != null)
            {
                Name = person.Name;
                Id = person.Id;
            }

            NotifyPropertyChanged(nameof(Name));
            
        }
        
        public void AddPerson()
        {
            if (Id <= 0)
            {
                ClientService.Current.Add(new Client { Name = Name });
            }
            else
            {
                var refToUpdate = ClientService.Current.Get(Id) as Client;
                refToUpdate.Name = Name;
            }
            //Shell.Current.GoToAsync("//Instructor");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
