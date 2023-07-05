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
            //EditCommand = new Command(
            //    (t) => ExecuteEdit((t as TimeViewModel).Model));
            EditCommand = new Command(ExecuteEdit);

            //AddCommand = AddCommand = new Command(ExecuteAdd);
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
    

        //public TimeViewModel(int projectId)
        //{

        //    Model = TimeService.Current.Get(projectId);
        //    SetupCommands();

        //}

        //THIS IS THE ADD THAT WORKS
        //private void ExecuteAdd()
        //{
        //    TimeService.Current.Add(Model);
        //    //Shell.Current.GoToAsync($"//TimeDetail?project={Model.ProjectId}");
        //    Shell.Current.GoToAsync($"//TimeDetail?date={Model.Date}");
        //}

        private void ExecuteEdit()
        {
            //TimeService.Current.Update(Model);
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

        //new
        public int ProjectId { get; set; }

        private void ExecuteAdd()
        {
            int projectId = TimeService.Current.GetProjectId(ProjectId);

            if (ProjectId == 0)
            {
                return;
            }

            Model.ProjectId = ProjectId;

            var project = ProjectService.Current.Get(ProjectId);
            if (project == null)
            {
                //Project does not exist
                return;
            }

            TimeService.Current.Add(Model);
            Shell.Current.GoToAsync($"//TimeDetail?project={Model.ProjectId}");

        }

    }
}
