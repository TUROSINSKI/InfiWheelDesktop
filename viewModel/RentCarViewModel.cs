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
        private Car? selectedCar;
        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                OnPropertyChanged("SelectedCar");
            }
        }
        public ObservableCollection<Car> RentedCars { get; } = new ObservableCollection<Car>();
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
                OnPropertyChanged("StartDate");
            }
        }

        private DateTime endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}