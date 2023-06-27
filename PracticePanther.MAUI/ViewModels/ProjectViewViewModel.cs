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
using PracticePanther.Library.Services;

namespace PracticePanther.MAUI.ViewModels
{
    public class ProjectViewViewModel : INotifyPropertyChanged
    {
        public Client Client { get; set; }

        public ObservableCollection<Project> Projects
        {
            get
            {
                if (Client == null || Client.Id == 0)
                {
                    return new ObservableCollection<Project>
                    (ProjectService.Current.Projects);
                }
                return new ObservableCollection<Project>
                    (ProjectService.Current.Projects
                    .Where(p => p.ClientId == Client.Id));
            }
        }

        /* public ObservableCollection<ProjectViewModel> Projects
         {
             get
             {
                 return
                    new ObservableCollection<ProjectViewModel>
                    (ProjectService
                        .Current.Search(Query ?? string.Empty)
                        .Select(p => new ProjectViewModel(p)).ToList());
             }
         }*/

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

        //new code 6/26
        public Project SelectedProject { get; set; }
        public ICommand SearchCommand { get; private set; }
        public string Query { get; set; }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        public ProjectViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Delete()
        {
            if (SelectedProject != null)
            {
                ProjectService.Current.Remove(SelectedProject.Id);
                SelectedProject = null;
                NotifyPropertyChanged(nameof(Projects));
                NotifyPropertyChanged(nameof(SelectedProject));
            }
        }

        public void RefreshProjectList()
        {
            NotifyPropertyChanged(nameof(Projects));
        }
        /*
    

    

      */
    }
}
