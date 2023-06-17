using PracticePanther.CLI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.Library.Services;
using System.Xml.Linq;

namespace PracticePanther.MAUI.ViewModels
{
    public class EditClientViewModel : INotifyPropertyChanged
    {
        private Client _client;

        public int Id
        {
            get => _client.Id;
        }

        public string Name
        {
            get => _client.Name;
            set
            {
                if (_client.Name != value)
                {
                    _client.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Notes
        {
            get => _client.Notes;
            set
            {
                if (_client.Notes != value)
                {
                    _client.Notes = value;
                    OnPropertyChanged(nameof(Notes));
                }
            }
        }

        public DateTime OpenDate
        {
            get => _client.OpenDate;
            set
            {
                if (_client.OpenDate != value)
                {
                    _client.OpenDate = value;
                    OnPropertyChanged(nameof(OpenDate));
                }
            }
        }

        public DateTime ClosedDate
        {
            get => _client.ClosedDate;
            set
            {
                if (_client.ClosedDate != value)
                {
                    _client.ClosedDate = value;
                    OnPropertyChanged(nameof(ClosedDate));
                }
            }
        }

        public EditClientViewModel(Client client)
        {
            _client = client;
        }

        public void Update()
        {
            // Implement the update logic here
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

   
}
