using PracticePanther.CLI.Models;
using PracticePanther.Library.Models;
using PracticePanther.Library.Services;
using PracticePanther.MAUI.ViewModels;
using System.Xml.Linq;

namespace PracticePanther.MAUI.Views;

[QueryProperty(nameof(PersonId), "PersonId")]
public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();
        //BindingContext = new PersonDetailViewModel();
    }

    public string PersonName
    {
        set; get;
    }
    public int PersonId
    {
        set; get;
    }

 


}