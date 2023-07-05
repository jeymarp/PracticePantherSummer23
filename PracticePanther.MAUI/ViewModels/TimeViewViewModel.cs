using PracticePanther.CLI.Models;
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
        public Time Model { get; set; }
        public Time SelectedTime { get; set; }
        //public ICommand SearchCommand { get; private set; }
        //public string Query { get; set; }
        public Project Project { get; set; }
        //public ObservableCollection<TimeViewModel> Times { get; set; }
        public ObservableCollection<TimeViewModel> times;
        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Times));
        }

        //public TimeViewViewModel()
        //{
        //    SearchCommand = new Command(ExecuteSearchCommand);
        //}

        //public ObservableCollection<TimeViewModel> Times
        //{
        //    get
        //    {
        //        return
        //            new ObservableCollection<TimeViewModel>
        //            (TimeService
        //                .Current.Search(Query ?? string.Empty)
        //                .Select(t => new TimeViewModel(t)).ToList());
        //    }
        //}


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
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TimeViewViewModel()
        {
            SelectedTime = new Time();
            RefreshTimeList();
        }

        public void RefreshTimeList()
        {
            Times = new ObservableCollection<TimeViewModel>(
            TimeService.Current.Times.ConvertAll(t => new TimeViewModel(t)));
            //NotifyPropertyChanged(nameof(Times));
        }

        //new
        public int ProjectId { get; set; }

    }
}
