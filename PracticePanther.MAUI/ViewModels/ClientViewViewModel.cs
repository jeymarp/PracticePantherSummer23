using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PracticePanther.MAUI.ViewModels
{
    public class ClientViewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Client> Clients
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Client>(ClientService.Current.ClientsList);
                }
                return new ObservableCollection<Client>(ClientService.Current.Search(Query));
            }
        }

        public string Query { get; set; }

        public void Search()
        {
            NotifyPropertyChanged(nameof(Clients));
        }
        public void Remove()
        {
            if (SelectedClient == null)
            {
                return;
            }
            ClientService.Current.Remove(SelectedClient);
            NotifyPropertyChanged(nameof(Clients));
        }

        public Client SelectedClient { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
