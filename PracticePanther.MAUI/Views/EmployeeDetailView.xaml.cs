using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModel;
using PracticePanther.MAUI.ViewModels;
namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "employeeId")]
public partial class EmployeeDetailView : ContentPage
{
	public int EmployeeId { get; set; }

    public decimal EmployeeRate { get; set; }
	public EmployeeDetailView()
	{
		InitializeComponent();
	}

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as EmployeeViewModel).AddOrUpdate(EmployeeRate);
        Shell.Current.GoToAsync("//Employees");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Employees");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EmployeeViewModel(EmployeeId);
        //(BindingContext as EmployeeViewModel).RefreshEmployeeList();
    }
}