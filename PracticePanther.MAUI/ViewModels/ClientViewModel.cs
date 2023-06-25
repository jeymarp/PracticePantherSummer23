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
    public class ClientViewModel //: INotifyPropertyChanged
    {
        public Client Model { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        //---------------------------- DELETE ---------------------------------------------------

        public ICommand DeleteCommand { get; private set; }
        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }

        //---------------------------- EDIT ---------------------------------------------------
        public ICommand EditCommand { get; private set; }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ClientDetail?clientId={id}");
        }

        //---------------------------- CONSTRUCTORS ------------------------------------------
        private void SetupCommands()
        {
            DeleteCommand = new Command(
                           (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
            EditCommand = new Command(
                   (c) => ExecuteEdit((c as ClientViewModel).Model.Id));
        }


        public ClientViewModel(Client client)
        {
            Model = client;
            SetupCommands();
        }

        public ClientViewModel(int clientId)
        {
            if(clientId == 0)
            {
                Model = new Client();
            } else
            {
                Model = ClientService.Current.Get(clientId);
            }
            SetupCommands();
        }

        public ClientViewModel()
        {
            Model = new Client();
            SetupCommands();

        }

        //------------------------------------- ADD ------------------------------------------

        public void AddOrUpdate()
        {
            ClientService.Current.AddOrUpdate(Model);
        }

        //------------------------------------- SEARCH ------------------------------------------

        /* public string Query { get; set; }
         public ICommand SearchCommand { get; private set; }
         public void ExecuteSearch(string Query)
         {
             ClientService.Current.Search(Query);
         }
         public void Search()
         {
             NotifyPropertyChanged(nameof(Model));
         }*/



        /*
        public ObservableCollection<Client> ClientsL
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
            NotifyPropertyChanged(nameof(ClientsL));
        }


         public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        //-------------------------------------------------------------------------------
        */

        //public Client SelectedClient { get; set; }  




    }
}
