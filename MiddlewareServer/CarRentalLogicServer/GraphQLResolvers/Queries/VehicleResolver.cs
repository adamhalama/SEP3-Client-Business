using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;
using CarRentalLogicServer.Services;
using CarRentalLogicServer.Services.Interfaces;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Queries
{
    // class containing query resolvers for getting data
    [ExtendObjectType(Name = "Query")]
    public class VehicleResolver
    {
        public IList<Vehicle> GetAllVehicles([Service] IVehicleService vehicleService)
        {
            try
            {
                return vehicleService.GetVehiclesAsync().Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IList<Vehicle> GetAvailableVehicles([Service] IVehicleService vehicleService, long startDate, long endDate)
        {
            try
            {
                return vehicleService.GetAvailableVehiclesAsync(startDate, endDate).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Vehicle> GetVehicle([Service] IVehicleService vehicleService, long id)
        {
            try
            {
                return await vehicleService.GetVehicleByIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}