using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class CarListPage : Page
    {
        public ObservableCollection<Car> Cars { get; set; }
        private readonly RentCarViewModel viewModel;
        public CarListPage()
        {
            viewModel = new RentCarViewModel();
            Cars = []; // Inicjalizacja kolekcji Cars
            LoadCars(); // Metoda do wczytania danych o samochodach
            InitializeComponent();
            DataContext = this;
        }

        private void LoadCars()
        {
            // Wczytanie danych o samochodach do kolekcji Cars
            Cars.Add(new Car { Name = "BMW e36", Description = "Kompakt stworzony z myślą o potencjalnych dawcach", Price = 50.00m, Location = "Location 1", Image = "E:\\Projekty\\WPF\\projectwpf\\InfiWheelDesktop\\InfiWheelDesktop\\assets\\car_image1.jpg" });
            Cars.Add(new Car { Name = "Audi Rs7", Description = "Audi rs7 idealne dla rodziny", Price = 60.00m, Location = "Location 2", Image = "E:\\Projekty\\WPF\\projectwpf\\InfiWheelDesktop\\InfiWheelDesktop\\assets\\car_image2.jpg" });
            // Dodaj więcej samochodów według potrzeb
        }

        private void RentNowButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCar = (sender as Button)?.DataContext as Car;

            // Przypisz wybrany samochód do SelectedCar w viewModel
            viewModel.SelectedCar = selectedCar;
            // Przekierowanie do strony wynajmu auta po kliknięciu przycisku "Rent Now"
            this.NavigationService.Navigate(new RentCarPage(viewModel));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingsPage());
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ProfilePage());
        }

        public class Car
        {
            public required string Name { get; set; }
            public required string Description { get; set; }
            public decimal Price { get; set; }
            public required string Location { get; set; }
            public required string Image { get; set; }
        }
    }
}
