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

        public decimal TotalAmount => CalculateTotalAmount();

        public DateTime DueDate => CalculateDueDate();

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }
       
        //constructors
        public BillViewModel()
        {
            Model = new Bill();
        }

        public BillViewModel(int projectId)
        {
            if (projectId == 0)
            {
                Model = new Bill();
            }
            else
            {
                Model = BillService.Current.GetId(projectId);
            }
            //SetupCommands();
        }
        public BillViewModel(int projectId, int billId)
        {
            if (billId > 0 && projectId > 0)
            {
                Model = BillService.Current.GetId(billId);
            }
            else if(projectId > 0)
            {
                Model = new Bill {ProjectId = projectId };
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
        private decimal CalculateTotalAmount()
        {
            decimal totalAmount = 0;

            // Calculate the total amount based on the time entries and employee rates
            foreach (var timeEntry in Model.Time)
            {
                if (timeEntry is Time typedTimeEntry)
                {
                    Employee employee = EmployeeService.Current.Get(typedTimeEntry.EmployeeId);
                    decimal? rate = employee?.Rate;
                    decimal hours = typedTimeEntry.Hours;

                    if (rate.HasValue)
                    {
                        totalAmount += hours * rate.Value;
                    }
                }
            }
            return totalAmount;
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
    }

}
