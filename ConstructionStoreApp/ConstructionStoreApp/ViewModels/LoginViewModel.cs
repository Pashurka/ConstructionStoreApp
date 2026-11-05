using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace ConstructionStoreApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _hasError;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public bool HasError
        {
            get => _hasError;
            set
            {
                _hasError = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            // Перевірка логіну та паролю

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Будь ласка, введіть логін та пароль.";
                HasError = true;
            }
            else if (Username == "dmytro@gmail.com" && Password == "password")
            {
                ErrorMessage = "";
                HasError = false;

                // Успішна авторизація
                await Shell.Current.GoToAsync("//AboutPage"); // Перехід на AboutePage
            }
            else
            {
                ErrorMessage = "Невірний логін або пароль.";
                HasError = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}