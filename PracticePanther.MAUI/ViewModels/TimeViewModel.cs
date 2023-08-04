using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.Library.DTO;

namespace PracticePanther.MAUI.ViewModels
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        public Time Model { get; private set; }
        public int TimeId { get; set; }
        private Time SelectedTime { get; set; }
        public DateTime OriginalEntryDate { get; set; } //Property to store the original entry date

        private Employee employee;
        public Employee Employee
        {
            get
            {
                return employee;
            }

            set
            {
                employee = value;
                if (employee != null)
                {
                    Model.EmployeeId = employee.Id;
                }
            }
        }

        private Project project;

        public ObservableCollection<EmployeeDTO> Employees
            => new ObservableCollection<EmployeeDTO> (EmployeeService.Current.Employees);

        public ObservableCollection<Project> Projects
            => new ObservableCollection<Project> (ProjectService.Current.Projects);

        public string Display
        {
            get
            {
                return $"{Model.Date} Hours: {Model.Hours} EmployeeId: {Model.EmployeeId} " +
                       $" ProjectId: {Model.ProjectId}";
            }
        }

        public string HoursDisplay
        {
            get
            {
                return Model.Hours.ToString();
            }

            set
            {
                if (decimal.TryParse(value, out decimal v))
                {
                    Model.Hours = v;
                }
            }
        }

        public Project Project
        {
            get
            {
                return project;
            }

            set
            {
                project = value;
                if (project != null)
                {
                    Model.ProjectId = project.Id;
                }
            }
        }

        public ICommand AddCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public DateTime Date { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (t) => ExecuteDelete((t as TimeViewModel).Model));
            EditCommand = new Command(ExecuteEdit);
            AddCommand = new Command(ExecuteAdd);
        }

        public TimeViewModel()
        {
            Model = new Time();
            SetupCommands();
        }
        public TimeViewModel(Time time)
        {
            Model = time;
            SetupCommands();
        }

        private void ExecuteEdit()
        {
            var time = TimeService.Current.Get(Model.TimeId);
            if (time == null)
            {
                //Time does not exist
                return;
            }

            OriginalEntryDate = time.Date;

            TimeService.Current.Update(Model);
            Shell.Current.GoToAsync($"//TimeDetail?date={Model.Date}");
        }

        public void ExecuteDelete(Time time)
        {
            TimeService.Current.Delete(time);
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Add()
        {
            TimeService.Current.Add(Model);
        }

        public void Edit()
        {
            TimeService.Current.Update(Model);
        }

        public int ProjectId { get; set; }
        public int EmployeeId { get; set; } //new

        private void ExecuteAdd()
        {
            int projectId = TimeService.Current.GetProjectId(Model.ProjectId);
            //new
            int employeeId = TimeService.Current.GetEmployeeId(Model.EmployeeId);

            if (Model.ProjectId == 0 || Model.EmployeeId == 0)
            {
                return;
            }

            var project = ProjectService.Current.Get(Model.ProjectId);
            if (project == null)
            {
                //Project does not exist
                return;
            }

            var employee = EmployeeService.Current.Get(Model.EmployeeId);
            if (employee == null)
            {
                // Employee does not exist
                return;
            }

            TimeService.Current.Add(Model);
            Shell.Current.GoToAsync($"//TimeDetail?project={Model.ProjectId}&employee={Model.EmployeeId}");

        }

        public TimeViewModel(int timeId)
        {
            var time = TimeService.Current.Get(timeId);
            if (time != null)
            {
                Model = time;
                SetupCommands();
            }
        }

        //--------------------------------------------------------------------------------
        //New code to extend the time functionality

    }
}
