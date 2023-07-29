using Microsoft.VisualBasic;
using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;
[QueryProperty(nameof(ProjectId), "projectId")]
[QueryProperty(nameof(ClientId), "clientId")]
[QueryProperty(nameof(BillId), "billId")]

public partial class BillDetailView : ContentPage
{
    public int ProjectId { get; set; }
    public int ClientId { get; set; }
    public int BillId { get; set; }
    public DateTime DueDate { get; set; }
    public BillDetailView()
	{
		InitializeComponent();
		//BindingContext = new BillViewModel();
	}

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new BillViewModel(ProjectId);
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientDetail");
    }

    //private void CreateBillClicked(object sender, EventArgs e)
    //{
    //    //(BindingContext as BillViewModel).Add();
    //    //Shell.Current.GoToAsync($"//ProjectDetail?projectId={ProjectId}");
    //    Shell.Current.GoToAsync("//ProjectDetail");
    //}

    //private void CalculateTotalAmountClicked(object sender, EventArgs e)
    //{
    //    var viewModel = (BillViewModel)BindingContext;

    //    if (viewModel != null && viewModel.Model != null)
    //    {
    //        // Call calculation logic within the BillViewModel, passing the time entries
    //        decimal totalAmount = viewModel.CalculateTotalAmount(viewModel.Model.Time);

    //        // Update the TotalAmount property in the view model
    //        viewModel.Model.TotalAmount = totalAmount;
    //    }
    //}

}