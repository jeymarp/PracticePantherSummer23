using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticePanther.MAUI.ViewModels
{
    public class ClientViewModel : INotifyPropertyChanged
    {
        public Client Model { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand DeleteCommand { get; private set; }
        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }

        public ClientViewModel(Client client)
        {
            Model = client;
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
        }

        public ClientViewModel()
        {
            Model = new Client();
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
        }

        public void Add()
        {
            ClientService.Current.Add(Model);
        }

        public ObservableCollection<Client> Clients
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Client>(ClientService.Current.Clients);
                }
                return new ObservableCollection<Client>(ClientService.Current.Search(Query));
            }
        }
        public string Query { get; set; }

        public void Search()
        {
            NotifyPropertyChanged(nameof(Clients));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
