using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;
namespace PracticePanther.MAUI.Views;

public partial class TimeView : ContentPage
{
	public TimeView()
	{
		InitializeComponent();
        BindingContext = new TimeViewViewModel();
	}
    
    private void EditClicked(object sender, EventArgs e)
    {
        var selectedTime = ((Button)sender).BindingContext as TimeViewModel;
        if (selectedTime != null)
        {
            // Handle edit logic
        }
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