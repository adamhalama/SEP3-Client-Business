using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models.REST;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Query
{
    // class containing query resolvers for getting data
    [ExtendObjectType(Name = "Query")]
    public class VehicleResolver
    {
        public IList<Vehicle> GetAllVehicles([Service] ICarService carService)
        {
            return carService.GetVehiclesAsync().Result;
        }

        public async Task<Vehicle> GetVehicle([Service] ICarService carService, int id)
        {
            return await carService.GetVehicleByIdAsync(id);
        }
    }
}