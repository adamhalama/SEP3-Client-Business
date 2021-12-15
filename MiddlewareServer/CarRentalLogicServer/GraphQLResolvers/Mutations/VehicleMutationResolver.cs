using System;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;
using CarRentalLogicServer.Services;
using CarRentalLogicServer.Services.Interfaces;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Mutations
{
    // class containing mutation resolvers for updating data
    [ExtendObjectType(Name = "Mutation")]
    public class VehicleMutationResolver
    {
        public async Task<Vehicle> CreateVehicle([Service] IVehicleService vehicleService, Vehicle vehicle)
        {
            try
            {
                return await vehicleService.CreateVehicleAsync(vehicle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Vehicle> UpdateVehicle([Service] IVehicleService vehicleService, Vehicle vehicle)
        {
            try
            {
                return await vehicleService.UpdateVehicleAsync(vehicle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Vehicle> DeleteVehicle([Service] IVehicleService vehicleService, long id)
        {
            try
            {
                return await vehicleService.DeleteVehicleAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}