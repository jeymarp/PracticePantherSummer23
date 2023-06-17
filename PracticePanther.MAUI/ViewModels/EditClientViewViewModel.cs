using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
    public class EditClientViewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<EditClientViewModel> Clients { get; }

        public EditClientViewViewModel()
        {
            Clients = new ObservableCollection<EditClientViewModel>(
                ClientService.Current.Clients.Select(c => new EditClientViewModel(c)));
        }

        public void Delete()
        {
            // Implement the delete logic here
        }

        public void RefreshClientList()
        {
            Clients.Clear();
            foreach (var client in ClientService.Current.Clients)
            {
                Clients.Add(new EditClientViewModel(client));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
