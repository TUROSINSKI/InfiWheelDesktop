using InfiWheelDesktop.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InfiWheelDesktop.CarListPage;

namespace InfiWheelDesktop
{
    public class RentCarViewModel : INotifyPropertyChanged
    {
        private CarModel? selectedCar;
        public CarModel SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                OnPropertyChanged(nameof(SelectedCar));
            }
        }
        public ObservableCollection<CarModel> RentedCars { get; } = new ObservableCollection<CarModel>();

        public void RentCar()
        {
            if (SelectedCar != null)
            {
                // Dodaj wybrane auto do listy wynajętych samochodów
                RentedCars.Add(SelectedCar);
            }
        }

        private DateTime startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}