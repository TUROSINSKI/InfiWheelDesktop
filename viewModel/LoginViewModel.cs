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
using System.Diagnostics;

namespace InfiWheelDesktop.viewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _password;
        private string _email;
        private string _message;
        private readonly Action _navigateToMainPage;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
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

        public ICommand LoginCommand { get; }

        public LoginViewModel(Action navigateToMainPage)
        {
            _navigateToMainPage = navigateToMainPage;
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            var userModel = new UserModel
            {
                password = Password,
                email = Email
            };

            var response = await UserService.Login(userModel);

            if (response.Success)
            {
                TokenManager.Instance.SetToken(response.Token);
                Message = "Login successful!";
                _navigateToMainPage();
                Debug.WriteLine($"Token after login: {TokenManager.Instance.GetToken()}");
            }
            else
            {
                Message = "Login failed. Please try again.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
