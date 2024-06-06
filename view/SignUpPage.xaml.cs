using InfiWheelDesktop.services;
using InfiWheelDesktop.viewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            SetPageTheme();
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
        private void SetPageTheme()
        {
            if (SettingsManager.Instance.GetDarkmode())
            {
                Main_Grid.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;
                Singup_Button.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.SidebarOrange) as SolidColorBrush;
                Singup_Button.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;
                Username.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
                Email.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
                Password.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
                Confirm_Password.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
            }
            else
            {
                Main_Grid.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgLightColor) as SolidColorBrush;
                Singup_Button.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;
                Singup_Button.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
                Username.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgLightColor) as SolidColorBrush;
                Email.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgLightColor) as SolidColorBrush;
                Password.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgLightColor) as SolidColorBrush;
                Confirm_Password.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgLightColor) as SolidColorBrush;
            }
        }
    }
}
