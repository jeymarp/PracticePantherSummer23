using System;
using System.Collections.Generic;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Windows.Input;
using PracticePanther.MAUI.ViewModel;
using PracticePanther.Library.DTO;

namespace PracticePanther.MAUI.ViewModels
{
    public class EmployeeViewViewModel : INotifyPropertyChanged
    {
        public Employee SelectedEmployee { get; set; }

        public ICommand SearchCommand { get; private set; }

        public string Query { get; set; }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Employees));
        }

        public EmployeeViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }
        public ObservableCollection<EmployeeViewModel> Employees
        {
            get
            {
                return
                    new ObservableCollection<EmployeeViewModel>
                    (EmployeeService
                        .Current.Search(Query ?? string.Empty)
                        .Select(e => new EmployeeViewModel(e)).ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Delete()
        {
            if (SelectedEmployee != null)
            {
                EmployeeService.Current.Delete(SelectedEmployee.Id);
                SelectedEmployee = null;
                NotifyPropertyChanged(nameof(Employees));
                NotifyPropertyChanged(nameof(SelectedEmployee));
            }
        }

        public void RefreshEmployeeList()
        {
            NotifyPropertyChanged(nameof(Employees));
        }

    }
}
