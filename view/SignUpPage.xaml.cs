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
        public SignUpPage()
        {
            InitializeComponent();
            DataContext = new viewModel.SignUpViewModel(NavigateToLoginPage);
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
            if (this.DataContext != null)
            {
                ((SignUpViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
