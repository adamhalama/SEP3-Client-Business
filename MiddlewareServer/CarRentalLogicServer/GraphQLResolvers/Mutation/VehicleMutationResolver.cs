using System;
using System.Net;
using System.Threading.Tasks;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models;
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