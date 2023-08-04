using PracticePanther.CLI.Models;
using System.ComponentModel;
using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using PracticePanther.Library.DTO;

namespace PracticePanther.MAUI.ViewModels
{
    public class BillViewModel : INotifyPropertyChanged
    {
        public Bill Model { get; set; }
        private decimal _totalAmount;

        public decimal TotalAmount
        {
            get => _totalAmount;
            set
            {
                if (_totalAmount != value)
                {
                    _totalAmount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Display
        {
            get
            {
                return Model.ToString();
            }
        }

        public ICommand AddCommand { get; private set; }


        public void ExecuteAdd()
        {
            CalculateTotalAmount(); // Calculate the total amount before adding the bill
            //Model.TotalAmount = _totalAmount;
            BillService.Current.Add(Model);
            Shell.Current.GoToAsync($"//ProjectDetail?projectId={ProjectService.Current.Get(Model.ProjectId).Id}&clientId={ProjectService.Current.Get(Model.ProjectId).ClientId}");
            
        }


        public void CalculateTotalAmount()
        {
           
            //decimal totalAmount = 0;

            foreach (Time timeEntry in TimeService.Current.Times)
            {
                EmployeeDTO employee = EmployeeService.Current.Get(timeEntry.EmployeeId);
                decimal? rate = employee?.Rate;
                decimal hours = timeEntry.Hours;

                if (rate.HasValue)
                {
                    Model.TotalAmount += hours * rate.Value;
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

     
        public DateTime DueDate => CalculateDueDate();

        private DateTime CalculateDueDate()
        {
            return DateTime.Now.AddDays(30); //due date after 30 days
        }

        //public BillViewModel()
        //{
        //    Model = new Bill();
        //    SetupCommands();
        //}

        private void SetupCommands()
        {
            AddCommand = new Command(ExecuteAdd);
        }
        public BillViewModel(int projectId)
        {
            if (projectId > 0)
            {
                Model = new Bill() { ProjectId = projectId };
               
            }
            //else
            //{
            //    Model = BillService.Current.GetId(projectId);
            //    CalculateTotalAmount();
            //}
            SetupCommands();
        }
        public BillViewModel(Bill model)
        {
            Model = model;
            SetupCommands();
            CalculateTotalAmount();
        }

        public BillViewModel(int projectId, int billId)
        {
            if (projectId > 0 && billId > 0)
            {
                Model = BillService.Current.GetId(projectId);
                CalculateTotalAmount();
            }
            else if (projectId > 0)
            {
                Model = new Bill { ProjectId = projectId };
            }
            SetupCommands();
        }

        public BillViewModel(DateTime dueDate)
        {
            Model = new Bill {DueDate = dueDate };
            SetupCommands();
        }

        public BillViewModel()
        {
            if (Model != null)
            {
                DateTime dueDate = CalculateDueDate();
                CalculateTotalAmount();
              
            }

        }



        //new
        public List<Bill> GetBillsForProject(int projectId)
        {
            return BillService.Current.GetBillByProjectId(projectId);
        }

    }

}
