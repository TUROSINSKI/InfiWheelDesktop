using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace InfiWheelDesktop
{
    public partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to LoginPage
            // Assuming you have a reference to the Frame from MainWindow
            this.NavigationService.Navigate(new LoginPage());
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to LoginPage
            // Assuming you have a reference to the Frame from MainWindow
            this.NavigationService.Navigate(new SignUpPage());
        }
    }
}
