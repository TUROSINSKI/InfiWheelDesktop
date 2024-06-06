﻿using InfiWheelDesktop.model;
using InfiWheelDesktop.services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace InfiWheelDesktop
{
    public partial class CarListPage : Page
    {
        public ObservableCollection<CarModel> Cars { get; set; }
        private readonly RentCarViewModel viewModel;

        public CarListPage()
        {
            InitializeComponent();

            viewModel = new RentCarViewModel();
            Cars = new ObservableCollection<CarModel>();
            DataContext = this;
            LoadCars(); // Asynchroniczne ładowanie samochodów

            SetPageTheme();
        }

        private void SetPageTheme()
        {
            if (SettingsManager.Instance.GetDarkmode())
            {
                Main_Grid.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;
                Car_List.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgColor) as SolidColorBrush;
                Car_List.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgColor) as SolidColorBrush;
            }
            else
            {
                Main_Grid.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgLightColor) as SolidColorBrush;
                Car_List.Background = new BrushConverter().ConvertFromString(SettingsManager.Instance.BgLightColor) as SolidColorBrush;
                Car_List.Foreground = new BrushConverter().ConvertFromString(SettingsManager.Instance.FgLightColor) as SolidColorBrush;
            }
        }

        private async void LoadCars()
        {
            var carsFromService = await CarService.GetCarsAsync();
            foreach (var car in carsFromService)
            {
                Cars.Add(car);
            }
        }

        private void RentNowButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCar = (sender as Button)?.DataContext as CarModel;

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
    }
}
