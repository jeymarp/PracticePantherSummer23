using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;
using PracticePanther.MAUI.Views;
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
    public class ProjectViewViewModel : INotifyPropertyChanged
    {
        public Client Client { get; set; }
        public Project SelectedProject { get; set; }
        public ICommand SearchCommand { get; private set; }
        public string Query { get; set; }

        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                if (Client == null || Client.Id == 0)
                {
                    return new ObservableCollection<ProjectViewModel>
                    ((IEnumerable<ProjectViewModel>)ProjectService.Current.Projects);
                }
                return new ObservableCollection<ProjectViewModel>
                    ((IEnumerable<ProjectViewModel>)ProjectService.Current.Projects
                    .Where(p => p.ClientId == Client.Id));
            }
        }

        public ProjectViewViewModel(int clientId)
        {
            if (clientId > 0)
            {
                Client = ClientService.Current.Get(clientId);
            }
            else
            {
                Client = new Client();
            }

        }
        //new code 6/30
        public void Delete()
        {
            if (SelectedProject != null)
            {
                ProjectService.Current.Delete(SelectedProject.Id);
                SelectedProject = null;
                NotifyPropertyChanged(nameof(Projects));
                NotifyPropertyChanged(nameof(SelectedProject));
            }
        }

        //here refresh

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        public ProjectViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }

        public void RefreshProjectList()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        /*

     public ObservableCollection<ProjectViewModel> Projects
      {
          get
          {
              return
                 new ObservableCollection<ProjectViewModel>
                 (ProjectService
                     .Current.Search(Query ?? string.Empty)
                     .Select(p => new ProjectViewModel(p)).ToList());
          }
      }
   */
    }
}
