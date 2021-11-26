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
        Task<string> GetVehiclesAsync();
        Task<string> GetVehicleByIdAsync(int id);
        Task<string> CreateVehicleAsync(string vehicle);
        Task<string> UpdateVehicleAsync(string vehicle, int id);
        Task<bool> DeleteVehicleAsync(int id);
        

    }
}