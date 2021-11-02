using CarRentalClientServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalClientServer.Data
{
    public interface ICarService
    {

       string SendMessage(string message);
       Task<IList<Car>> GetCarsAsync();
        void AddCar(Car car);
        void RemoveCar(int carId);
        void UpdateCar(Car car);
        Car GetSpcificCar (int carId);
    }
}
