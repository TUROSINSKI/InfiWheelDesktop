using InfiWheelDesktop.services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InfiWheelDesktop
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            Darkmode_checkbox.IsChecked = SettingsManager.Instance.GetDarkmode();
            //SettingsManager.Instance.SetPageTheme(Main_Grid, Content_Stack);
            SetPageTheme();
        }

        private void SetPageTheme()
        {
            if (SettingsManager.Instance.GetDarkmode())
            {
                Main_Grid.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;

                List<TextBlock> textBlocks = Helper.FindVisualChildren<TextBlock>(Content_Stack);
                List<Separator> separators = Helper.FindVisualChildren<Separator>(Content_Stack);

                foreach (TextBlock textBlock in textBlocks)
                {
                    textBlock.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
                }
                foreach (Separator separator in separators)
                {
                    separator.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
                }
            }
            else
            {
                Main_Grid.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgLightColor) as SolidColorBrush;

                List<TextBlock> textBlocks = Helper.FindVisualChildren<TextBlock>(Content_Stack);
                List<Separator> separators = Helper.FindVisualChildren<Separator>(Content_Stack);

                foreach (TextBlock textBlock in textBlocks)
                {
                    textBlock.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgLightColor) as SolidColorBrush;
                }
                foreach (Separator separator in separators)
                {
                    separator.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgLightColor) as SolidColorBrush;
                }
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new CarListPage());
        }

        private void Darkmode_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            SettingsManager.Instance.SetDarkmode(true);
            SetPageTheme();
        }

        private void Darkmode_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            SettingsManager.Instance.SetDarkmode(false);
            SetPageTheme();
        }
    }
}
