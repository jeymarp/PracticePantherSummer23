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
using Microsoft.Maui.Controls;

namespace PracticePanther.MAUI.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        private Bill r;

        public Project Model { get; set; }
  
        public ICommand TimerCommand { get; private set; }
        public ICommand AddClientCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand CloseCommand { get; private set; }

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
            var window = new Window()
            {
                Width = 250,
                Height = 350,
                X = 0,
                Y = 0
            };
            var view = new TimerView(Model.Id, window);
            window.Page = view;
            Application.Current.OpenWindow(window);
        }
        
        public void ExecuteDelete()
        {
            ProjectService.Current.Delete(Model.Id);
        }

        public async void ExecuteClose()
        {

            Model.IsActive = false;
            ProjectService.Current.Delete(Model);
           await Application.Current.MainPage.DisplayAlert("Success", "Project closed successfully.", "OK");
        }

       public void ExecuteEdit()
       {
          int ClientId = Model.ClientId;
          int ProjectId = Model.Id;
          Shell.Current.GoToAsync($"//ProjectDetail?projectId={ProjectId}&clientId={ClientId}");
       }

        private void SetupCommands()
        {
            AddClientCommand = new Command(ExecuteAdd);
            TimerCommand = new Command(ExecuteTimer);
            DeleteCommand = new Command(ExecuteDelete);
            EditCommand = new Command(ExecuteEdit);
            CloseCommand = new Command(ExecuteClose);
            //new for bill
            ShowBillsCommand = new Command(
                (p) => ExecuteShowBills((p as ProjectViewModel).Model.Id));
            CreateBillCommand = new Command(ExecuteCreateBill);
        }

        public ProjectViewModel()
        {
            Model = new Project();
            SetupCommands();
        }

        public ProjectViewModel(int clientId)
        {
            if (clientId == 0)
            {
                Model = new Project();
            }
            else
            {
                Model = ProjectService.Current.Get(clientId);
            }
            SetupCommands();
        }

        public ProjectViewModel(Project model)
        {
            Model = model;
            SetupCommands();              
        }
        public ProjectViewModel(int clientId, int projectId)
        {
            if (projectId > 0 && clientId > 0)
            {
                Model = ProjectService.Current.Get(projectId);
            }
            else if (clientId > 0)
            {
                Model = new Project { ClientId = clientId };
            }
            SetupCommands();
        }

        public void Add()
        {
            ProjectService.Current.Add(Model);
        }
    
        public void Edit()
        {
            ProjectService.Current.Edit(Model);
        }

        public void Delete()
        {
            ProjectService.Current.Delete(Model);
        }

        //---------------------------- BILL -------------------------------
        // ProjectViewModel
        public ICommand CreateBillCommand { get; private set; }
        public ICommand ShowBillsCommand { get; private set; }
        public List<Time> Times { get; private set; }
        public ProjectViewModel(Bill r)
        {
            this.r = r;
        }

        public void ExecuteShowBills(int id)
        {
            //Shell.Current.GoToAsync($"//BillDetail?projectId={id}");
        }

        public void ExecuteCreateBill()
        {
            //Add();
            Shell.Current.GoToAsync($"//BillDetail?projectId={Model.Id}");

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<BillViewModel> Bills
        {
            get
            {
                if (Model == null || Model.Id == 0)
                {
                    return new ObservableCollection<BillViewModel>();
                }
                return new ObservableCollection<BillViewModel>(BillService
                    .Current.Bills.Where(b => b.ProjectId == Model.Id)
                    .Select(r => new BillViewModel(r)));
            }
        }

        public void RefreshBillsList()
        {
            NotifyPropertyChanged(nameof(Bills));
        }
    }
}
