using PracticePanther.MAUI.ViewModels;
namespace PracticePanther.MAUI.Views;

public partial class BillView : ContentPage
{
	public BillView()
	{
		InitializeComponent();
        BindingContext = new BillViewViewModel();
	}

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as BillViewViewModel).RefreshBillsList();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }
}