
using PracticePanther.CLI.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;

namespace PracticePanther.MAUI.Views;

public partial class ClientDetailView : ContentPage
{
	public ClientDetailView()
	{
		InitializeComponent();
        BindingContext = new ClientViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientViewModel).Add();
        Shell.Current.GoToAsync("//Client");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }
    //working on it
    private void EditClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EditClient");
    }
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