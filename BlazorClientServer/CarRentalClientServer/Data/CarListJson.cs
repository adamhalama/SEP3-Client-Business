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
                WriteTodosToFile();
            }
            else
            {
                string content = File.ReadAllText(carFile);
                cars = JsonSerializer.Deserialize<List<Car>>(content);
            }
        }

        private void WriteTodosToFile()
        {
            string todoAsJson = JsonSerializer.Serialize(cars);
            File.WriteAllText(carFile, todoAsJson);
        }
        public void AddCar(Car car)
        {
            int max = cars.Max(car => car.Id);
            car.Id = (++max);

            cars.Add(car);
            WriteTodosToFile();
        }

        public IList<Car> GetCars()
        {
            throw new System.NotImplementedException();
        }

        public Car GetSpcificCar(int carId)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCar(int carId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCar(Car car)
        {
            throw new System.NotImplementedException();
        }
    }
}
