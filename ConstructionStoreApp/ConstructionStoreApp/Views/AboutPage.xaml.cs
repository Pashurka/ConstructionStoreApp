using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConstructionStoreApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync("https://www.fcit.od.ua/kaf_info/");
        }
    }
}

