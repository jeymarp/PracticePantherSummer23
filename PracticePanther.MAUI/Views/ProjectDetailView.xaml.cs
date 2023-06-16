using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class ProjectDetailView : ContentPage
{
	public ProjectDetailView()
	{
		InitializeComponent();
		BindingContext = new ProjectDetailViewModel();
	}

	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}

	private void OkClicked(object sender, EventArgs e)
	{
		var viewModel = (ProjectDetailViewModel)BindingContext;
		viewModel.AddProject(Shell.Current);
		//(BindingContext as ProjectDetailView).AddProject(Shell.Current);
    }
}