using ConstructionStoreApp.ViewModels;
using ConstructionStoreApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ConstructionStoreApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
//            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }

        private async void OnMenuExitClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
