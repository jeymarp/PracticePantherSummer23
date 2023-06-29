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
        //BindingContext = new ProjectViewViewModel();
    }
   
    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext =new ProjectViewViewModel(ClientId);
    }


    /*private void GoBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    //new code------------------------------------------
    private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectViewViewModel).RefreshProjectList();
    }
      /*
   private void AddClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ProjectDetail");
    }

     private void EditClicked(object sender, EventArgs e)
     {
         (BindingContext as ProjectViewViewModel).RefreshProjectList();
     }
     private void ClientsClicked(object sender, EventArgs e)
     {
         (BindingContext as ProjectViewViewModel).RefreshProjectList();
     }*/
}