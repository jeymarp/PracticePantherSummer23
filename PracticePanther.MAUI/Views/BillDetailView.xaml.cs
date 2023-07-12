using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class BillDetailView : ContentPage
{
	public BillDetailView()
	{
		InitializeComponent();
		BindingContext = new BillViewModel();
	}

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new BillViewModel();
    }

    private void CalculateTotalAmount_Clicked(object sender, EventArgs e)
	{

	}
}