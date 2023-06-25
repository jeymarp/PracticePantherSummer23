using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;


namespace PracticePanther.MAUI.ViewModels
{/*
    public class EditClientViewViewModel : INotifyPropertyChanged
    {
        public EditClientViewViewModel(int clientId)
        {
            if(clientId > 0)
            {
                SelectedClient = new EditClientViewModel(ClientService.Current.Get(clientId));
            }
        }
        public EditClientViewModel SelectedClient { get; set; }
      
        public ObservableCollection<EditClientViewModel> Clients
        {
            get
            {
                return new ObservableCollection<EditClientViewModel>(ClientService
                    .Current.Clients
                    .Select(c => new EditClientViewModel(c)).ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Edit()
        {
            if (SelectedClient != null)
            {
                ClientService.Current.Delete(SelectedClient.Model.Id);
                NotifyPropertyChanged(nameof(Clients));
                NotifyPropertyChanged(nameof(SelectedClient));
            }
        }

        public void RefreshClientList()
        {
            {
                NotifyPropertyChanged(nameof(Clients));
            }
        }
       
     



    }*/
}
