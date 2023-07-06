using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.Controls;
using PracticePanther.MAUI.ViewModels;
using PracticePanther.MAUI.Views;
using PracticePanther.CLI.Models;


namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(EmployeeId), "employeeId")]
[QueryProperty(nameof(ProjectId), "projectId")]
[QueryProperty(nameof(TimeId), "timeId")]
public partial class TimeDetailView : ContentPage
{
    public int EmployeeId { get; set; }
    public int ProjectId { get; set; }
    public int TimeId { get; set; }

    public Time Model { get; set; }
    public TimeDetailView()
	{
		InitializeComponent();
      
	}

    //private void OkClicked(object sender, EventArgs e)
    //{
    //    (BindingContext as TimeViewModel).Add();
    //    Shell.Current.GoToAsync("//Time");
    //}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Time");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewModel).Edit();
        Shell.Current.GoToAsync($"//Time?timeId={TimeId}");

        //Shell.Current.GoToAsync("//Time");

        // (BindingContext as TimeViewViewModel).RefreshTimeList();
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new TimeViewModel();
    }

    //new
    private void OkClicked(object sender, EventArgs e)
    {
        var timeViewModel = (BindingContext as TimeViewModel);
        timeViewModel.ProjectId = ProjectId;
        timeViewModel.Add();
        Shell.Current.GoToAsync("//Time");
    }
}