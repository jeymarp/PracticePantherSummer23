using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticePanther.MAUI.ViewModels
{
    public class TimeViewViewModel : INotifyPropertyChanged
    {
        public Time SelectedTime { get; set; }

        public Time Model { get; set; }
        public ObservableCollection<TimeViewModel> times;
        public ObservableCollection<TimeViewModel> Times
        {
            get
            {
                return times;
            }
            set
            {
               times = value;
                NotifyPropertyChanged();
            }
        }

        public TimeViewViewModel()
        {
            SelectedTime = new Time();
            RefreshTimeList();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RefreshTimeList()
        {
            Times = new ObservableCollection<TimeViewModel>(
                TimeService.Current.Times.ConvertAll(t => new TimeViewModel(t)));
         }
    }
}
