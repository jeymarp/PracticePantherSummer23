﻿using System;
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
using PracticePanther.MAUI.Views;

namespace PracticePanther.MAUI.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public Project Model { get; set; }
  
        public ICommand TimerCommand { get; private set; }
        public ICommand AddClientCommand { get; private set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        private void ExecuteAdd()
        {
            ProjectService.Current.Add(Model);
            Shell.Current.GoToAsync($"//ClientDetail?clientId={Model.ClientId}");
        }

        private void ExecuteTimer()
        {
            var window = new Window(new TimerView(Model.Id))
            {
                Width = 250,
                Height = 350,
                X = 0,
                Y = 0
            };
            Application.Current.OpenWindow(window);
        }

        private void SetupCommands()
        {
            AddClientCommand = new Command(ExecuteAdd);
            TimerCommand = new Command(ExecuteTimer);
            DeleteCommand = new Command(ExecuteAdd);
            EditCommand = new Command(ExecuteAdd);
            ShowClientsCommand = new Command(ExecuteAdd);
        }

        public ProjectViewModel()
        {
            Model = new Project();
            SetupCommands();
        }

        public ProjectViewModel(int clientId)
        {

            Model = new Project { ClientId = clientId };
            SetupCommands();
        }

        public ProjectViewModel(Project model)
        {
            Model = model;
            SetupCommands();
        }


        //NEW code 6/26-----------------------------------------------------------------
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
      
        public ICommand ShowClientsCommand { get; private set; }
        public ObservableCollection<ClientViewModel> Clients
        {
            get
            {
                return new ObservableCollection<ClientViewModel>(ClientService
                    .Current.Clients.Where(c => c.ProjectId == Model.Id)
                    .Select(r => new ClientViewModel(r)));
            }
        }

        public void ExecuteDelete(int id)
        {
            ProjectService.Current.Remove(id);
        }

        public void ExecuteShowClients(int id)
        {
            Shell.Current.GoToAsync($"//Client?projectId={id}");
        }

        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//ProjectDetail?projectId={id}");
        }

        public void RefreshClients()
        {
            NotifyPropertyChanged(nameof(Clients));
        }

        public void ExecuteAddClient()
        {
            Add(); 
            Shell.Current.GoToAsync($"//ClientDetail?projectId={Model.Id}");
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Add()
        {
            ProjectService.Current.Add(Model);
        }


        /*
       
         private void SetupCommands()
        {
            DeleteCommand = new Command(
                (p) => ExecuteDelete((p as ProjectViewModel).Model.Id));
            EditCommand = new Command(
                (p) => ExecuteEdit((p as ProjectViewModel).Model.Id));
            AddClientCommand = new Command(
                (p) => ExecuteAddClient());
            ShowClientsCommand = new Command(
                (p) => ExecuteShowClients((p as ClientViewModel).Model.Id));
        }
       

      */

    }
}