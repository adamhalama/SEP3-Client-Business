using CarRentalClientServer.Models;
using System.Collections.Generic;

namespace CarRentalClientServer.Data
{
    public interface ICarList
    {
        IList<Car> GetAllCars();
        void AddCar(Car car);
        void RemoveCar(int carId);
        void UpdateCar(Car car);
        Car GetSpecifiedCar (int carId);
    }
}
