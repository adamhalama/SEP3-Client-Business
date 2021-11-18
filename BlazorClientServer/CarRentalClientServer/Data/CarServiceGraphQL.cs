using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data
{
    public class CarServiceGraphQL : ICarService
    {
        public string SendMessage(string message)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Car>> GetCarsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Car AddCar(Car car)
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

        public Car GetSpcificCar(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}