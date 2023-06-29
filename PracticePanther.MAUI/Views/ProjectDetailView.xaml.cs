using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using PracticePanther.Library.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
[QueryProperty(nameof(ProjectId), "projectId")]
public partial class ProjectDetailView : ContentPage
{
    public int ClientId { get; set; }
    public int Query { get; set; }
    public int ProjectId { get; set; }
    public ProjectDetailView()
    {
        InitializeComponent();
        BindingContext = new ProjectViewModel();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Clients");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        //var viewModel = (ProjectViewModel)BindingContext;
        //viewModel.Add(Shell.Current);
        (BindingContext as ProjectViewModel).Add();
        Shell.Current.GoToAsync($"//ClientDetail?clientId={ClientId}");

    }

    private void OnArrived(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectViewModel(ClientId, ProjectId);
        //(BindingContext as ProjectViewModel).RefreshClients();
    }
	
}