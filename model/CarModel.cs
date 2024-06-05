using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiWheelDesktop.model
{
    public class CarModel
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string YearOfProduction { get; set; }
        public string VinNumber { get; set; }
        public double EngineCapacity { get; set; }
        public int Power { get; set; }
        public required string FuelType { get; set; }
        public string Transmission { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfSeats { get; set; }
        public string RegistrationPlate { get; set; }
        public string RegistrationNumber { get; set; }
        public string Ac { get; set; }
        public string Url { get; set; }
        public double XLocation { get; set; }
        public double YLocation { get; set; }
    }
}
