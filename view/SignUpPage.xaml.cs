using InfiWheelDesktop.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InfiWheelDesktop
{
    /// <summary>
    /// Logika interakcji dla klasy SignUpPage.xaml
    /// </summary>
    public partial class SignUpPage : Page
    {

        private SignUpViewModel viewModel;
        public SignUpPage()
        {
            InitializeComponent();
            viewModel = new SignUpViewModel(NavigateToLoginPage);
            this.DataContext = viewModel;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to LoginPage
            // Assuming you have a reference to the Frame from MainWindow
            this.NavigationService.Navigate(new MainPage());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to LoginPage
            // Assuming you have a reference to the Frame from MainWindow
            this.NavigationService.Navigate(new LoginPage());
        }

        private void NavigateToLoginPage()
        {
            // Navigate to MainPage
            this.Dispatcher.Invoke(() =>
            {
                this.NavigationService.Navigate(new LoginPage());
            });
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                viewModel.Password = passwordBox.Password;
            }
        }

        private void ConfirmPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                viewModel.ConfirmPassword = passwordBox.Password;
            }
        }
    }
}
