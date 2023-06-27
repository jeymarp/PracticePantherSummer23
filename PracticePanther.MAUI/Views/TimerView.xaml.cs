using PracticePanther.MAUI.ViewModels;
using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
using PracticePanther.CLI.Models;

namespace PracticePanther.MAUI.Views;

public partial class TimerView : ContentPage
{
	public TimerView(int projectId)
    {
		InitializeComponent();
        BindingContext = new TimerViewModel(projectId);
    }
}