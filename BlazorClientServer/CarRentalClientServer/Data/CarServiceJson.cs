using CarRentalClientServer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarRentalClientServer.Data
{
    public class VehicleServiceJson : IVehicleService
    {
        private string carFile = "vehicle.json";
        private IList<Vehicle> cars;

        public VehicleServiceJson()
        {
            if (!File.Exists(carFile))
            {
                //Seed();
                WriteCarsToFile();
            }
            else
            {
                string content = File.ReadAllText(carFile);
                cars = JsonSerializer.Deserialize<List<Vehicle>>(content);
            }
        }

        private void WriteCarsToFile()
        {
            string todoAsJson = JsonSerializer.Serialize(cars);
            File.WriteAllText(carFile, todoAsJson);
        }
        public Vehicle AddCar(Vehicle vehicle)
        {
            int max = cars.Max(car => car.Id);
            vehicle.Id = (++max);

            cars.Add(vehicle);
            WriteCarsToFile();
            return vehicle;
        }

        public void StartClient()
        {
            throw new System.NotImplementedException();
        }

        public string SendMessage(string message)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Vehicle>> GetCarsAsync()
        {
            List<Vehicle> tmp = new List<Vehicle>(cars);
            return tmp;
        }

        public Vehicle GetSpcificCar(int carId)
        {
            return cars.FirstOrDefault(c => c.Id == carId);
        }

        public void RemoveCar(int carId)
        {
            Vehicle vehicleRemove = cars.First(c => c.Id == carId);
            cars.Remove(vehicleRemove);
            WriteCarsToFile();
        }

        public void UpdateCar(Vehicle vehicle)
        {
            Vehicle vehicleUpdate = cars.First(c => c.Id == vehicle.Id);
            WriteCarsToFile();
        }
    }
}
