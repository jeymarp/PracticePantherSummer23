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

namespace PracticePanther.MAUI.ViewModels
{
    public class TimeViewModel //: INotifyPropertyChanged
    {
        public Time Model { get; private set; }
        private Time SelectedTime { get; set; }
        public DateTime OriginalEntryDate { get; set; } //Property to store the original entry date

        //public int TimeId {get; set;} 
        public string Display
        {
            get
            {
                return $"{Model.Date}";
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

        private void ExecuteAdd()
        {
            int projectId = TimeService.Current.GetProjectId(Model.ProjectId);

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
            Shell.Current.GoToAsync($"//TimeDetail?project={Model.ProjectId}");

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
