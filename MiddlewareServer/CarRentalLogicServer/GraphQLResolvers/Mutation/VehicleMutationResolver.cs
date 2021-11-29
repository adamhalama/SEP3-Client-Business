using System;
using System.Threading.Tasks;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models;
using CarRentalLogicServer.Models.REST;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Mutation
{
    // class containing mutation resolvers for updating data
    [ExtendObjectType(Name = "Mutation")]
    public class VehicleMutationResolver
    {
        public async Task<Vehicle> CreateVehicle([Service] IVehicleService vehicleService, Vehicle vehicle)
        {
            return await vehicleService.CreateVehicleAsync(vehicle);
        }

        public async Task<Vehicle> UpdateVehicle([Service] IVehicleService vehicleService, Vehicle vehicle)
        {
            return await vehicleService.UpdateVehicleAsync(vehicle);
        }

        public async Task<bool> DeleteVehicle([Service] IVehicleService vehicleService, int id)
        {
            return await vehicleService.DeleteVehicleAsync(id);
        }
    }
}