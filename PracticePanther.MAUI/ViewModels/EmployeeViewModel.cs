using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModel 
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public Employee Model { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ExecuteDelete(int id)
        {
            EmployeeService.Current.Delete(id);
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//EmployeeDetail?employeeId={id}");
        }

        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (e) => ExecuteDelete((e as EmployeeViewModel).Model.Id));
            EditCommand = new Command(
                (e) => ExecuteEdit((e as EmployeeViewModel).Model.Id));
        }

        public EmployeeViewModel(Employee employee)
        {
            Model = employee;
            SetupCommands();
        }

        public EmployeeViewModel(int employeeId)
        {
            if (employeeId == 0)
            {
                Model = new Employee();
            }
            else
            {
                Model = EmployeeService.Current.Get(employeeId);
            }
            SetupCommands();
        }

        public EmployeeViewModel()
        {
            Model = new Employee();
            SetupCommands();
        }

        public void AddOrUpdate(decimal rate)
        {
            EmployeeService.Current.AddOrUpdate(Model, rate);
        }
    }
}
