namespace PracticePanther.MAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void ClientClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Client");
        }

        private void ProjectClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Project");
        }
    }
}