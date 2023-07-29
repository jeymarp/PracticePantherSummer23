using PracticePanther.CLI.Models;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ProjectView : ContentPage
{
    public int ClientId { get; set; }
    public ProjectView()
	{
		InitializeComponent();
    }
   
    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext =new ProjectViewViewModel(ClientId);
    }
}