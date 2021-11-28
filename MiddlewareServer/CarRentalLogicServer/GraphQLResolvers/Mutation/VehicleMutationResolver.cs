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
        public async Task<Vehicle> CreateVehicle([Service] ICarService carService, Vehicle vehicle)
        {
            return await carService.CreateVehicleAsync(vehicle);
        }

        public async Task<Vehicle> UpdateVehicle([Service] ICarService carService, Vehicle vehicle)
        {
            return await carService.UpdateVehicleAsync(vehicle);
        }

        public async Task<bool> DeleteVehicle([Service] ICarService carService, int id)
        {
            return await carService.DeleteVehicleAsync(id);
        }
    }
}