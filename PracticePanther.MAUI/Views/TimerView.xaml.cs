using PracticePanther.MAUI.ViewModels;
using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
using PracticePanther.CLI.Models;

namespace PracticePanther.MAUI.Views;

public partial class TimerView : ContentPage
{
	public TimerView(int projectId, Window parentWindow)
    {
		InitializeComponent();
        BindingContext = new TimerViewModel(projectId, parentWindow);
    }

    //private void StartClicked(object sender, EventArgs e)
    //{
    //    (BindingContext as TimerViewModel).Equals(true);
    //}

    //private void StopClicked(object sender, EventArgs e)
    //{
    //    (BindingContext as TimerViewModel).Equals(false);
    //}
}