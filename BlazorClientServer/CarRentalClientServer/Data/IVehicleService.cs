using CarRentalClientServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalClientServer.Data
{
    public interface IVehicleService
    {

        //rename to vehicle
       string SendMessage(string message);
       Task<IList<Vehicle>> GetCarsAsync();
        Vehicle AddCar(Vehicle vehicle);
        void RemoveCar(int carId);
        void UpdateCar(Vehicle vehicle);
        Vehicle GetSpcificCar (int carId);
    }
}
