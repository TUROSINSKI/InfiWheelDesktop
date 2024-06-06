using InfiWheelDesktop.model;
using InfiWheelDesktop.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InfiWheelDesktop.viewModel.LandingViewModel;
using System.Windows.Input;
using System.Windows;

namespace InfiWheelDesktop.viewModel
{
    public class SignUpViewModel : INotifyPropertyChanged
    {

        private string _username;
        private string _password;
        private string _confirmPassword;
        private string _email;
        private string _message;
        private readonly Action _navigateToMainPage;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public ICommand SignUpCommand { get; }

        public SignUpViewModel(Action navigateToMainPage)
        {
            _navigateToMainPage = navigateToMainPage;
            SignUpCommand = new RelayCommand(async () => await SignUpAsync());
        }

        private bool CanSignUp()
        {
            return !string.IsNullOrEmpty(Username) &&
                   !string.IsNullOrEmpty(Email) &&
                   !string.IsNullOrEmpty(Password) &&
                   !string.IsNullOrEmpty(ConfirmPassword);
        }

        private async Task SignUpAsync()
        {
            if (!CanSignUp())
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!ValidatePasswords())
            {
                return;
            }

            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.ShowLoading();

            var userModel = new UserModel
            {
                username = Username,
                password = Password,
                email = Email
            };

            bool success = await UserService.SignUp(userModel);

            if (success)
            {
                _navigateToMainPage();
                MessageBox.Show("Now you can login!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Sign-up failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            mainWindow?.HideLoading();
        }

        private bool ValidatePasswords()
        {
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Passwords are not the same!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
