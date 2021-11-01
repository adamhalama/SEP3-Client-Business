using CarRentalClientServer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CarRentalClientServer.Data
{
    public class CarListJson : CarList
    {
        private string carFile = "car.json";
        private IList<Car> cars;

        public CarListJson()
        {
            if (!File.Exists(carFile))
            {
                //Seed();
                WriteCarsToFile();
            }
            else
            {
                string content = File.ReadAllText(carFile);
                cars = JsonSerializer.Deserialize<List<Car>>(content);
            }
        }

        private void WriteCarsToFile()
        {
            string todoAsJson = JsonSerializer.Serialize(cars);
            File.WriteAllText(carFile, todoAsJson);
        }
        public void AddCar(Car car)
        {
            int max = cars.Max(car => car.Id);
            car.Id = (++max);

            cars.Add(car);
            WriteCarsToFile();
        }

        public IList<Car> GetCars()
        {
            List<Car> tmp = new List<Car>(cars);
            return tmp;
        }

        public Car GetSpcificCar(int carId)
        {
            return cars.FirstOrDefault(c => c.Id == carId);
        }

        public void RemoveCar(int carId)
        {
            Car carRemove = cars.First(c => c.Id == carId);
            cars.Remove(carRemove);
            WriteCarsToFile();
        }

        public void UpdateCar(Car car)
        {
            Car carUpdate = cars.First(c => c.Id == car.Id);
            WriteCarsToFile();
        }
    }
}
