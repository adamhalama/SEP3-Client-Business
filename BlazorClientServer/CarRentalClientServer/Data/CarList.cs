using CarRentalClientServer.Models;
using System.Collections.Generic;

namespace CarRentalClientServer.Data
{
    public interface CarList
    {
        IList<Car> GetCars();
        void AddCar(Car car);
        void RemoveCar(int carId);
        void UpdateCar(Car car);
        Car GetSpcificCar (int carId);
    }
}
