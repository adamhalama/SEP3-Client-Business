using System;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models.REST;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Mutation
{
    [ExtendObjectType(Name = "Mutation")]
    public class VehicleMutationResolver
    {
        public Vehicle CreateVehicle([Service] ICarService carService, Vehicle vehicle)
        {
            return carService.CreateVehicleAsync(vehicle).Result;
        }

        public void DeleteVehicle([Service] ICarService carService, int id)
        {
            carService.DeleteVehicleAsync(id);
        }
    }
}