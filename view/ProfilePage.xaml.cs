using InfiWheelDesktop.services;
using InfiWheelDesktop.viewModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;

namespace InfiWheelDesktop
{
    /// <summary>
    /// Logika interakcji dla klasy ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            DataContext = new ProfilePageViewModel();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CarListPage());
        }

        private void OrderHistoryButton_Click(object sender, RoutedEventArgs e)
        {
            return;
        }
        private async void DeleteAccountButton_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show($"Do you really want to delete your account forewer? (This is a really long time)", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (messageBoxResult != MessageBoxResult.Yes) return;
            try
            {
                using (var client = new HttpClient())
                {
                    string token = TokenManager.Instance.GetToken();
                    client.BaseAddress = new Uri("https://infiwheel.azurewebsites.net");
                    client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(1000000));

                    HttpResponseMessage response = new HttpResponseMessage();
                    string userId = await RentCarService.GetUserIdFromToken(token);

                    response = await client.DeleteAsync($"/User/delete/{userId}");
                    response.EnsureSuccessStatusCode();

                    this.NavigationService.Navigate(new LoginPage());
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error deleting the account, try again later");
                return;
            }

        }
    }
}
