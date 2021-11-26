using CarRentalClientServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalClientServer.Data
{
    public interface IVehicleService
    {

        //rename to vehicle
        Task<IList<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> GetVehicleAsync(int id);
        Task<Vehicle>    CreateVehicleAsync(Vehicle vehicle);
        Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
        Task<bool> DeleteVehicleAsync(int id);
    }
}
