﻿using PracticePanther.CLI.Models;
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
                       .Current.Clients.Where(c => c.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty))
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

        public void Edit()
        {
            Shell.Current.GoToAsync($"//EditClient?clientId={SelectedClient?.Id ?? 0 }");
        }

        public void RefreshClientList()
        {
            NotifyPropertyChanged(nameof(Clients));
        }


        public string Query { get; set; }

        public void Search()
        {
           // ClientService.Current.Search(Query);    //new
            NotifyPropertyChanged(nameof(Clients));
        }
        //-------------------------------------------------------------------------------
        /*
        
       

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }*/

    }
}
