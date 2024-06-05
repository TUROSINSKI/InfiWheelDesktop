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
        }

        private void RentNowButton_Click(object sender, RoutedEventArgs e)
        {
            // Pobierz dane z kontekstu danych ViewModelu
            string carName = viewModel.SelectedCar.Name;
            DateTime startDate = viewModel.StartDate;
            DateTime endDate = viewModel.EndDate;

            // Przykładowa logika rezerwacji auta
            MessageBox.Show($"Car '{carName}' has been reserved from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}.");
            this.NavigationService.Navigate(new CarListPage());
        }
    }
}
