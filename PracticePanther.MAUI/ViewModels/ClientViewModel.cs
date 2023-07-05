using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
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
    public class ClientViewModel : INotifyPropertyChanged
    {
        public Client Model { get; set; }

        public ObservableCollection<ProjectViewModel> Projects
        {
            get
            {
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<ProjectViewModel>();
                }
                return new ObservableCollection<ProjectViewModel>(ProjectService
                    .Current.Projects.Where(p => p.ClientId == Model.Id)
                    .Select(r => new ProjectViewModel(r)));
            }
        }
        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand AddProjectCommand { get; private set; }
        public ICommand EditProjectCommand { get; private set; }
        public ICommand DeleteProjectCommand { get; private set; } 
        public ICommand ShowProjectsCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //---------------------------- DELETE CLIENT---------------------------------------------------
        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }

        //---------------------------- EDIT CLIENT ---------------------------------------------------
        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ClientDetail?clientId={id}");
        }

        //---------------------------- ADD PROJECT, EDIT & DELETE--------------------------------------
        public void ExecuteShowProjects(int id)
        {
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={id}");
        }
        public void ExecuteAddProject()
        {
            AddOrUpdate();
            // Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.Id}&projectId={0}");
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.Id}");
        }

        //new
        public void ExecuteEditProject()
        {
            AddOrUpdate();
            Shell.Current.GoToAsync($"//ProjectDetail?clientId={Model.Id}&projectId{0}");
        }

        public void ExecuteDeleteProject(int id)
        {
            ProjectService.Current.Delete(id);
        }

        public void RefreshProjects()
        {
            NotifyPropertyChanged(nameof(Projects));
        }

        //---------------------------- CONSTRUCTORS ------------------------------------------
        private void SetupCommands()
        {
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));
            EditCommand = new Command(
                (c) => ExecuteEdit((c as ClientViewModel).Model.Id));
            AddProjectCommand = new Command(
                (c) => ExecuteAddProject());
            ShowProjectsCommand = new Command(
                (c) => ExecuteShowProjects((c as ClientViewModel).Model.Id));
            EditProjectCommand = new Command(
                (c) => ExecuteEditProject());
            DeleteProjectCommand = new Command(
                (c) => ExecuteDeleteProject((c as ClientViewModel).Model.Id));
        }


        public ClientViewModel(Client client)
        {
            Model = client;
            SetupCommands();
        }

        public ClientViewModel(int clientId)
        {
            if (clientId == 0)
            {
                Model = new Client();
            }
            else
            {
                Model = ClientService.Current.Get(clientId);
            }
            SetupCommands();
        }

        public ClientViewModel()
        {
            Model = new Client();
            SetupCommands();

        }

        //------------------------------------- ADD/UPD CLIENT ------------------------------------------

        public void AddOrUpdate()
        {
            if(Model.Id == 0)
            ClientService.Current.AddOrUpdate(Model);
        }

     

        //------------------------------------- SEARCH ------------------------------------------

        /* public string Query { get; set; }
         public ICommand SearchCommand { get; private set; }
         public void ExecuteSearch(string Query)
         {
             ClientService.Current.Search(Query);
         }
         public void Search()
         {
             NotifyPropertyChanged(nameof(Model));
         }*/



        /*
        public ObservableCollection<Client> ClientsL
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Client>(ClientService.Current.Clients);
                }
                return new ObservableCollection<Client>(ClientService.Current.Search(Query));
            }
        }
        
        public string Query { get; set; }

        public void Search()
        {
            NotifyPropertyChanged(nameof(ClientsL));
        }


         public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        //-------------------------------------------------------------------------------
        */

        //public Client SelectedClient { get; set; }  




    }
}
