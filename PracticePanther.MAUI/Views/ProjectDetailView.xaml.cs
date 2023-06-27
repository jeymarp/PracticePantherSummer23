using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectDetailView : ContentPage
{
    public int ClientId { get; set; }
    public ProjectDetailView()
    {
        InitializeComponent();
        BindingContext = new ProjectViewModel();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        //var viewModel = (ProjectViewModel)BindingContext;
        //viewModel.Add(Shell.Current);
        (BindingContext as ProjectViewModel).Add();
        Shell.Current.GoToAsync("//Projects");
    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewModel(ClientId);
        (BindingContext as ProjectViewModel).RefreshClients();
    }
	
}