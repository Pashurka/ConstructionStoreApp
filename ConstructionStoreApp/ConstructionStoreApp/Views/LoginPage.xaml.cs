using ConstructionStoreApp.ViewModels;
using Xamarin.Forms;

namespace ConstructionStoreApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(); // Встановлення ViewModel
        }
    }
}