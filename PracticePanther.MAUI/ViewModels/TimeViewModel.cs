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
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Time> Times { get; private set; }

        public Time Model { get; private set; }
        private Time SelectedTime { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand AddTimeCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public DateTime Date { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (t) => ExecuteDelete((t as TimeViewModel).Model));
            /*EditCommand = new Command(
                (e) => ExecuteEdit((e as TimeViewModel).Model.Id));*/
        }

        public TimeViewModel(Time time)
        {
            Model = time;
            SetupCommands();
        }

        private void AddTime()
        {
            // Implementation for adding a new time entry
            // create a separate page or use a dialog to gather the required information
            // The information can be obtained using dialogs or binding to properties in this ViewModel
            // After gathering the information, create a new Time object and add it to the TimeService
        }

        private void EditTime()
        {
            // Implementation for editing a selected time entry
            // Similar to the AddTime method, gather the necessary information and update the selected Time object
        }

        public void ExecuteDelete(Time time)
        {
            TimeService.Current.Delete(time);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
