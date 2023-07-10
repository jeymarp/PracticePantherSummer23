using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;
namespace PracticePanther.MAUI.Views;

public partial class TimeView : ContentPage
{
    public int ProjectId { get; set; } 

    public TimeView()
	{
		InitializeComponent();
        BindingContext = new TimeViewViewModel();
	}

    private void AddClicked(object sender, EventArgs e)
    {
        var timeViewViewModel = (BindingContext as TimeViewViewModel);
        timeViewViewModel.ProjectId = ProjectId;
        timeViewViewModel.RefreshTimeList();
        Shell.Current.GoToAsync("//TimeDetail");
    }

    private void EditClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//TimeDetail");
        //(BindingContext as TimeViewViewModel).RefreshTimeList();
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as TimeViewViewModel).RefreshTimeList();
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as TimeViewViewModel).RefreshTimeList();
    }

}