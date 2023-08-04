using System.ComponentModel;
using System.Windows.Input;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.Library.DTO;

namespace PracticePanther.MAUI.ViewModel 
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public EmployeeDTO Model { get; set; }

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

        public EmployeeViewModel(EmployeeDTO employee)
        {
            Model = employee;
            SetupCommands();
        }

        public EmployeeViewModel(int employeeId)
        {
            if (employeeId > 0)
            {
                Model = EmployeeService.Current.Get(employeeId);
            }
            else
            {
                Model = new EmployeeDTO();
            }
            SetupCommands();
        }

        public EmployeeViewModel()
        {
            Model = new EmployeeDTO();
            SetupCommands();
        }

        public void AddOrUpdate()
        {
            EmployeeService.Current.AddOrUpdate(Model);
        }
    }
}
