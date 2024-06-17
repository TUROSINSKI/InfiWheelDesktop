using InfiWheelDesktop.services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using InfiWheelDesktop.model;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace InfiWheelDesktop
{
    /// <summary>
    /// Logika interakcji dla klasy Page1.xaml
    /// </summary>
    public partial class RentCarPage : Page
    {
        private RentCarViewModel viewModel;

        public RentCarPage(RentCarViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = this.viewModel; // Ustaw kontekst danych na ViewModel
            SetPageTheme();
        }

        private async void RentNowButton_Click(object sender, RoutedEventArgs e)
        {
            long carId = viewModel.SelectedCar.Id;
            string carName = viewModel.SelectedCar.Manufacturer;
            DateTime startDate = viewModel.StartDate;
            DateTime endDate = viewModel.EndDate;
            await RentCarService.SaveBooking(carId, startDate.ToShortDateString(), endDate.ToShortDateString());
            

            MessageBox.Show($"Car '{carName}' has been reserved from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}.");
            this.NavigationService.Navigate(new CarListPage());
        }

        private void SetPageTheme()
        {
            if (SettingsManager.Instance.GetDarkmode())
            {
                Main_Grid.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;
                Rent_Button.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.SidebarOrange) as SolidColorBrush;
                Rent_Button.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;
                List<TextBlock> textBlocks = Helper.FindVisualChildren<TextBlock>(Rent_Stack);

                foreach (TextBlock textBlock in textBlocks)
                {
                    textBlock.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
                }
            }
            else
            {
                Main_Grid.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgLightColor) as SolidColorBrush;
                Rent_Button.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;
                Rent_Button.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
                List<TextBlock> textBlocks = Helper.FindVisualChildren<TextBlock>(Rent_Stack);

                foreach (TextBlock textBlock in textBlocks)
                {
                    textBlock.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgLightColor) as SolidColorBrush;
                }
            }
        }
    }
}
