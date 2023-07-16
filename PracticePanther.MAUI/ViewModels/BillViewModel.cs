using PracticePanther.CLI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
using System.Xml.Linq;
using System.Windows.Input;
using Microsoft.VisualBasic;

namespace PracticePanther.MAUI.ViewModels
{
    public class BillViewModel : INotifyPropertyChanged
    {
        public Bill Model { get; set; }

        private decimal _totalAmount;

        public decimal TotalAmount
        {
            get { return _totalAmount; }
        }
        public DateTime DueDate => CalculateDueDate();

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }
       
        public BillViewModel(int projectId, int billId)
        {
            if (projectId > 0)
            {
                if (billId > 0)
                {
                    Model = BillService.Current.GetId(billId);
                }
                else
                {
                    Model = new Bill { ProjectId = projectId };
                }
            }
            //SetupCommands();
        }
        public BillViewModel(Bill model)
        {
            Model = model;
        }

        public BillViewModel(DateTime dueDate)
        {
            Model = new Bill {DueDate = dueDate };
        }
     

        private DateTime CalculateDueDate()
        {
            return DateTime.Now.AddDays(30); //due date after 30 days
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //new
        private readonly BillService _billService;
        private readonly EmployeeService _employeeService;

        public BillViewModel()
        {
            _billService = BillService.Current;
            _employeeService = EmployeeService.Current;

            Model = new Bill();
            if (Model.Time == null)
                Model.Time = new List<Time>(); //Initialize Time collection if it's null.
        }

        public BillViewModel(int projectId)
        {
            _billService = BillService.Current;
            _employeeService = EmployeeService.Current;

            Model = _billService.GetId(projectId) ?? new Bill { ProjectId = projectId };
        }

        public BillViewModel(List<Time> timeEntries)
        {
            Model = new Bill { Time = timeEntries ?? new List<Time>() };
            CalculateTotalAmount(Model.Time); // Calculate and initialize the TotalAmount property.
        }

        public decimal CalculateTotalAmount(List<Time> timeEntries)
        {
            decimal totalAmount = 0;

            foreach (var timeEntry in timeEntries)
            {
                Employee employee = _employeeService.Get(timeEntry.EmployeeId);
                decimal? rate = employee?.Rate;
                decimal hours = timeEntry.Hours;

                if (rate.HasValue)
                {
                    totalAmount += hours * rate.Value;
                }
            }

            return totalAmount;
        }

        //new
        public List<Bill> GetBillsForProject(int projectId)
        {
            return BillService.Current.GetBillByProjectId(projectId);
        }


        //constructors
        //public BillViewModel()
        //{
        //    Model = new Bill();
        //}

        //public BillViewModel(int projectId)
        //{
        //    if (projectId == 0)
        //    {
        //        Model = new Bill();
        //    }
        //    else
        //    {
        //        Model = BillService.Current.GetId(projectId);
        //    }
        //    //SetupCommands();
        //}

        //public decimal CalculateTotalAmount()
        //{
        //    decimal totalAmount = 0;

        //    if (Model != null && Model.Time != null)
        //    {
        //        foreach (var timeEntry in Model.Time)
        //        {
        //            if (timeEntry is Time typedTimeEntry)
        //            {
        //                Employee employee = _employeeService.Get(typedTimeEntry.EmployeeId);
        //                decimal? rate = employee?.Rate;
        //                decimal hours = typedTimeEntry.Hours;

        //                if (rate.HasValue)
        //                {
        //                    totalAmount += hours * rate.Value;
        //                }
        //            }
        //        }
        //    }

        //    return totalAmount;
        //}

    }

}
