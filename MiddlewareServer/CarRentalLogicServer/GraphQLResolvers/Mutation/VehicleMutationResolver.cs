using System;
using System.Threading.Tasks;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models.REST;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Mutation
{
    // class containing mutation resolvers for updating data
    [ExtendObjectType(Name = "Mutation")]
    public class VehicleMutationResolver
    {
        public async Task<string> CreateVehicle([Service] ICarService carService, string vehicle)
        {
            //legacy not using json
            //return await carService.CreateVehicleAsync(vehicle);

            return await carService.CreateVehicleAsync(vehicle);
        }

        public string UpdateVehicle([Service] ICarService carService, string vehicle, int id)
        {
            return carService.UpdateVehicleAsync(vehicle, id).Result;
        }

        public bool DeleteVehicle([Service] ICarService carService, int id)
        {
            return carService.DeleteVehicleAsync(id).Result;
        }
    }
}