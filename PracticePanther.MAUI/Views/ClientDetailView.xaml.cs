
using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class ClientDetailView : ContentPage
{
    public int ClientId { get; set; }
	public ClientDetailView()
	{
		InitializeComponent();
        
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//Client");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientViewModel(ClientId);
    }
    //working on it

    /*
  private void AddClicked(object sender, EventArgs e)
  {
      (BindingContext as ClientViewViewModel).AddClicked(Shell.Current);
  }

  private void EditClicked(object sender, EventArgs e)
  {
      (BindingContext as ClientViewViewModel).EditClicked(Shell.Current);
  }

  private void DeleteClick(object sender, EventArgs e)
  {
      (BindingContext as ClientViewViewModel).Delete();
  }

  private void GoBackClicked(object sender, EventArgs e)
  {
      Shell.Current.GoToAsync("//MainPage");
  }

  private void CloseClientClicked(object sender, EventArgs e) 
  { 

  }

  private void CloseProjectClicked(object sender, EventArgs e)
  {

  }*/
}