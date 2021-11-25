using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalLogicServer.Models.REST;

namespace CarRentalLogicServer.APIConsumer
{
    public interface ICarService
    {
        Task<IList<Car>> GetCarsAsync();
        Task<Car> CreateCarAsync(Car car);
        
        //Vehicles
        Task<IList<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int id);
        

    }
}