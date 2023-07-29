using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class ClientView : ContentPage
{
	public ClientView()
	{
		InitializeComponent();
        BindingContext = new ClientViewViewModel();

    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientDetail");
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    private void ProjectsClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
        
    }

    private void CloseClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewViewModel).RefreshClientList();
    }

    //Client Bills 
    private void BillsClientClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//BillView");
    }
}