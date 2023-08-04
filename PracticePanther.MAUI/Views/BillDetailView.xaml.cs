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

}