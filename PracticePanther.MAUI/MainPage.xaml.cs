﻿namespace PracticePanther.MAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void ClientsClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Clients");
        }
     
        
        private void TimeClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Time");
        }

        private void EmployeeClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//Employees");
        }
    }
}