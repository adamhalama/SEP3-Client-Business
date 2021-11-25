using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalLogicServer.Models.REST;

namespace CarRentalLogicServer.APIConsumer
{
    public interface IVehicleService
    {
        Task<IList<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> CreateVehicleAsync();
    }
}