using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Time> Times { get; private set; }

        public Time Model { get; private set; }
        private Time selectedTime;
        public Time SelectedTime
        {
            get { return selectedTime; }
            set { SetProperty(ref selectedTime, value); }
        }

        public ICommand AddTimeCommand { get; private set; }
        public ICommand EditTimeCommand { get; private set; }
        public ICommand DeleteTimeCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TimeViewModel()
        {
            Times = new ObservableCollection<Time>(TimeService.Current.Times);

            AddTimeCommand = new Command(AddTime);
            EditTimeCommand = new Command(EditTime, CanEditTime);
            DeleteTimeCommand = new Command(DeleteTime, CanDeleteTime);
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

        private bool CanEditTime()
        {
            return SelectedTime != null;
        }

        private void DeleteTime()
        {
            // Implementation for deleting the selected time entry
            if (SelectedTime != null)
            {
                TimeService.Current.Delete(Model);
                Times.Remove(SelectedTime);
            }
        }

        private bool CanDeleteTime()
        {
            return SelectedTime != null;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
