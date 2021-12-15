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
    public class ReservationResolver
    {
        public IList<Reservation> GetAllReservations([Service] IReservationService reservationService)
        {
            try
            {
                return reservationService.GetReservationsAsync().Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Reservation> GetReservation([Service] IReservationService reservationService, long id)
        {
            try
            {
                return await reservationService.GetReservationByIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public IList<Reservation> GetReservationsByVehicle([Service] IReservationService reservationService, long id)
        {
            try
            {
                return reservationService.GetReservationsByVehicleAsync(id).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }       
        public IList<Reservation> GetReservationsByCustomer([Service] IReservationService reservationService, long id)
        {
            try
            {
                return reservationService.GetReservationsByCustomerAsync(id).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }       
        public IList<Reservation> GetReservationsByEmployee([Service] IReservationService reservationService, long id)
        {
            try
            {
                return reservationService.GetReservationsByEmployeeAsync(id).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        
    }
}