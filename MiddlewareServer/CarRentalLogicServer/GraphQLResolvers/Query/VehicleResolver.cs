using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Query
{
    // class containing query resolvers for getting data
    [ExtendObjectType(Name = "Query")]
    public class VehicleResolver
    {
        public IList<Vehicle> GetAllVehicles([Service] IVehicleService vehicleService)
        {
            return vehicleService.GetVehiclesAsync().Result;
        }

        public async Task<Vehicle> GetVehicle([Service] IVehicleService vehicleService, int id)
        {
            return await vehicleService.GetVehicleByIdAsync(id);
        }
    }
}