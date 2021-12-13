using CarRentalClientServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalClientServer.Data
{
    public interface IVehicleService
    {

        //rename to vehicle
        Task<IList<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> GetVehicleAsync(long id);
        Task<IList<Vehicle>> GetAvailableVehiclesAsync(long startDate, long endDate);
        
        Task<Vehicle> CreateVehicleAsync(string name, string type, int pricePerDay, int seatsCount, bool isAutomatic,
            int powerKw, string fuelType, int deposit);
        Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
        Task<bool> DeleteVehicleAsync(long id);
        
    }
}
