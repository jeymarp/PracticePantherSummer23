using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.CLI.Models;
using System.Windows.Input;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.Views;

namespace PracticePanther.MAUI.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        public Project Project { get; set; }
        public int SelectedEmployee { get; set; }

        public List<int> EmployeesId
        {
            get
            {
                List<int> result = new List<int>();
                foreach(Employee employees in EmployeeService.Current.Employees)
                {
                    result.Add(employees.Id);
                }
                return result;
            }
        }
        public List<Project> Projects
        {
            get
            {
                return ProjectService.Current.Projects;
            }
        }
        public string TimerDisplay
        {
            get
            {
                var time = stopwatch.Elapsed;
                var str = string.Format("{0:00}:{1:00}:{2:00}",
              time.Hours,
              time.Minutes,
              time.Seconds);
                return str;
            }
        }
        public string ProjectDisplay
        {
            get
            {
                return Project.LongName;
            }
        }

        private Window parentWindow;

        private IDispatcherTimer timer { get; set; }
        private Stopwatch stopwatch { get; set; }

        public ICommand StartCommand { get; private set; }
        public ICommand StopCommand { get; private set; }
        public ICommand SubmitCommand { get; private set; }

        public void ExecuteStart()
        {
            stopwatch.Start();
            timer.Start();
        }

        public void ExecuteStop()
        {
            stopwatch.Stop();
        }

        public void ExecuteSubmit()
        {
            if (SelectedEmployee != 0 && stopwatch.Elapsed.TotalHours > 0)
            {
                TimeService.Current.Add(new Time {Date = DateTime.Now, Hours = (Decimal)stopwatch.Elapsed.TotalHours,
                                                  ProjectId = Project.Id, EmployeeId = SelectedEmployee});
                Application.Current.CloseWindow(parentWindow);
            }
        }

        private void SetupCommands()
        {
            StartCommand = new Command(ExecuteStart);
            StopCommand = new Command(ExecuteStop);
            SubmitCommand = new Command(ExecuteSubmit);
        }

        public TimerViewModel(int projectId, Window parentWindow)
        {
            Project = ProjectService.Current.Get(projectId) ?? new Project();
            stopwatch = new Stopwatch();
            timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.IsRepeating = true;

            timer.Tick += Timer_Tick;
            SetupCommands();
            this.parentWindow = parentWindow;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timer.IsRunning)
            {
                NotifyPropertyChanged(nameof(TimerDisplay));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
