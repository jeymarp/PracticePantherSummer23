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

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<BillViewModel> Bills
        {
            get
            {
                if ((Project.Id == 0) && Client != null && (Client.Id as int?) > 0)
                {
                    return new ObservableCollection<BillViewModel>(BillService
                        .Current.Search(Query ?? string.Empty).Where(p => p.ClientId.Equals(Client.Id))
                        .Select(r => new BillViewModel(r)));
                }
                if (Project.Id == 0 || Client == null || Client.Id == 0)
                {
                    return new ObservableCollection<BillViewModel>();
                }
                return new ObservableCollection<BillViewModel>(
                    BillService.Current.Search(Query ?? string.Empty)
                    .Where(p => (int)p.ClientId == Client.Id)
                    .Select(r => new BillViewModel(r)));
            }
        }

    }

}

//public BillViewViewModel(int projectId)
//{
//    ProjectViewModel = new ProjectViewModel(projectId);
//    Bills = new ObservableCollection<BillViewModel>(
//        ProjectViewModel.Model.Bills.Select(bill => new BillViewModel { Model = bill })
//    );
//}

//public BillViewViewModel(ClientViewModel clientViewModel)
//{
//    Bills = new ObservableCollection<BillViewModel>();

//    foreach (var projectViewModel in clientViewModel.Projects)
//    {
//        foreach (var bill in projectViewModel.Model.Bills)
//        {
//            Bills.Add(new BillViewModel { Model = bill });
//        }
//    }
//}


