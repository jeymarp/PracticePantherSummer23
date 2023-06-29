using PracticePanther.MAUI.ViewModels;
namespace PracticePanther.MAUI.Views;

public partial class EmployeeView : ContentPage
{
	public EmployeeView()
	{
		InitializeComponent();
        BindingContext = new EmployeeViewViewModel();
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }
    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EmployeeDetail");
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewViewModel).RefreshEmployeeList();
    }
}
