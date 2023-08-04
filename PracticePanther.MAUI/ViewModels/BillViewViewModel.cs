using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Windows.Input;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.Views;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.ViewModels
{
    public class BillViewViewModel : INotifyPropertyChanged
    {
       
        public ProjectViewModel ProjectViewModel { get; set; }

        public Project Project { get; set; }
        public Project SelectedBill { get; set; }
        public ClientViewModel ClientViewModel { get; set; }
        public Client Client { get; set; }
        public ICommand SearchCommand { get; private set; }
        public string Query { get; set; }

        public void ExecuteSearchCommand()
        {
            NotifyPropertyChanged(nameof(Bills));
        }

        public BillViewViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BillViewViewModel(int projectId)
        {
            if (projectId > 0)
            {
                Project = ProjectService.Current.Get(projectId);
            }
            else
            {
                Project = new Project();
            }

        }
        public void RefreshBillsList()
        {
            NotifyPropertyChanged(nameof(Bills));
        }
        public ObservableCollection<BillViewModel> Bills
        {
            get
            {
                if ((Project == null || Project.Id == 0) && Client != null && (Client.Id as int?) > 0)
                {
                    return new ObservableCollection<BillViewModel>(BillService
                        .Current.Search(Query ?? string.Empty).Where(p => p.ClientId.Equals(Client.Id))
                        .Select(r => new BillViewModel(r)));
                }
                if (Project == null || Project.Id == 0 || Client == null || Client.Id == 0)
                {
                    return new ObservableCollection<BillViewModel>();
                }
                return new ObservableCollection<BillViewModel>(
                    BillService.Current.Search(Query ?? string.Empty)
                    .Where(p => ((p.ClientId == Client.Id) && (p.ProjectId == Project.Id)))
                    .Select(r => new BillViewModel(r)));
            }
        }

        public void RefreshBillList()
        {
            NotifyPropertyChanged(nameof(Bills));
        }
    }

}



