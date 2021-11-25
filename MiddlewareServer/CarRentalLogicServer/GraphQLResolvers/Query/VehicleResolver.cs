using System.Collections.Generic;
using System.Linq;
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
        public List<Vehicle> GetAllVehicles([Service] ICarService carService)
        {
            return carService.GetVehiclesAsync().Result.ToList();
        }

        public Vehicle GetVehicle([Service] ICarService carService, int id)
        {
            return carService.GetVehicleByIdAsync(id).Result;
        }
        
        
    }
}