using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;
using System.Xml.Linq;

namespace PracticePanther.MAUI.Views;


public partial class EditClientView : ContentPage
{
	public EditClientView()
	{
		InitializeComponent();
        BindingContext = new EditClientViewViewModel();
    }

    private void OkClicked(object sender, EventArgs e)
    {
        //in this line goes update call
        Shell.Current.GoToAsync("//Client");
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }




}