using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalLogicServer.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<List<Models.Vehicle>> GetVehiclesAsync();
        Task<List<Models.Vehicle>> GetAvailableVehiclesAsync(long startDate, long endDate);
        Task<Models.Vehicle> GetVehicleByIdAsync(long id);
        Task<Models.Vehicle> CreateVehicleAsync(Models.Vehicle vehicle);
        Task<Models.Vehicle> UpdateVehicleAsync(Models.Vehicle vehicle);
        Task<Models.Vehicle> DeleteVehicleAsync(long id);
        

    }
}