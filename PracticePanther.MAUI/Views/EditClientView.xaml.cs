using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;
using System.Xml.Linq;
//using static Java.Util.Jar.Attributes;

namespace PracticePanther.MAUI.Views;

public partial class EditClientView
{
    //public int ClientId { get; set; }
    //private EditClientViewViewModel viewModel;
    public EditClientView()
    {
        InitializeComponent();
        //BindingContext = new EditClientViewViewModel(ClientId);
    }
}

/*
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Client");
    }

}*/