using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalLogicServer.APIConsumer
{
    public interface IVehicleService
    {
        Task<List<Models.Vehicle>> GetVehiclesAsync();
        Task<Models.Vehicle> GetVehicleByIdAsync(long id);
        Task<Models.Vehicle> CreateVehicleAsync(Models.Vehicle vehicle);
        Task<Models.Vehicle> UpdateVehicleAsync(Models.Vehicle vehicle);
        Task<Models.Vehicle> DeleteVehicleAsync(long id);
        

    }
}