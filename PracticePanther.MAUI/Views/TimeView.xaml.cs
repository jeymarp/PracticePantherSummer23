using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;
namespace PracticePanther.MAUI.Views;

public partial class TimeView : ContentPage
{
	public TimeView()
	{
		InitializeComponent();
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
        var selectedTime = ((Button)sender).BindingContext as TimeViewModel;
        if (selectedTime != null)
        {
            // Handle delete logic
        }
    }

    private void GoBackClicked(object sender, EventArgs e)
    {
        // Handle go back logic
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
       // (BindingContext as TimeViewModel).LoadTimes();
    }

}