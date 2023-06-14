
using PracticePanther.MAUI.ViewModels;
namespace PracticePanther.MAUI.Views;

public partial class ClientView : ContentPage
{
	public ClientView()
	{
		InitializeComponent();
        BindingContext = new ClientViewViewModel();
    }


    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).Search();
    }

    private void DeleteClick(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).Remove();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}