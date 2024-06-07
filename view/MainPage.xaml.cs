using InfiWheelDesktop.services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InfiWheelDesktop
{
    public partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
            SetPageTheme();
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

        private void SetPageTheme()
        {
            if (SettingsManager.Instance.GetDarkmode())
            {
                Main_Grid.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;
                changeTextButton.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.SidebarOrange) as SolidColorBrush;
                changeTextButton.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;
                displayTextBlock.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
            }
            else
            {
                Main_Grid.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgLightColor) as SolidColorBrush;
                changeTextButton.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;
                changeTextButton.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
                displayTextBlock.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgLightColor) as SolidColorBrush;
            }
        }
    }
}
