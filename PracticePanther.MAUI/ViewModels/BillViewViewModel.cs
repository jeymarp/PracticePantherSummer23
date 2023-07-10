using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;


namespace PracticePanther.MAUI.ViewModels
{
    public class BillViewViewModel
    {
        public ProjectViewModel ProjectViewModel { get; set; }

        public ObservableCollection<BillViewModel> Bills { get; set; }

        public BillViewViewModel(int projectId)
        {
            ProjectViewModel = new ProjectViewModel(projectId);
            Bills = new ObservableCollection<BillViewModel>(
                ProjectViewModel.Model.Bills.Select(bill => new BillViewModel { Model = bill })
            );
        }

        public BillViewViewModel(ClientViewModel clientViewModel)
        {
            Bills = new ObservableCollection<BillViewModel>();

            foreach (var projectViewModel in clientViewModel.Projects)
            {
                foreach (var bill in projectViewModel.Model.Bills)
                {
                    Bills.Add(new BillViewModel { Model = bill });
                }
            }
        }


    }

}
