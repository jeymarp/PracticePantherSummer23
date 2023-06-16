using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace PracticePanther.MAUI.ViewModels
{
    public class ClientViewViewModel : INotifyPropertyChanged
    {
        public Client SelectedClient { get; set; }
        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                return
                   new ObservableCollection<ClientViewModel>
                   (ClientService
                       .Current.Clients
                       .Select(c => new ClientViewModel(c)).ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Delete()
        {
            if (SelectedClient != null)
            {
                ClientService.Current.Delete(SelectedClient.Id);
                SelectedClient = null;
                NotifyPropertyChanged(nameof(Clients));
                NotifyPropertyChanged(nameof(SelectedClient));
            }
        }

        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Clients));
        }

        public void Search()
        {
            NotifyPropertyChanged(nameof(Clients));
        }
        /*public string Query { get; set; }

       
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

       

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddClicked(Shell c)
        {
            c.GoToAsync("//Person");
        }

        public void EditClicked(Shell e)
        {
            e.GoToAsync("//Client");
        }*/

    }
}
