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
        Task<List<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);
        Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
        Task<bool> DeleteVehicleAsync(int id);
        

    }
}