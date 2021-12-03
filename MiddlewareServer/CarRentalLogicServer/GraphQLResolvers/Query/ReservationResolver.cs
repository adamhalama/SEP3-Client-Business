using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Query
{
    // class containing query resolvers for getting data
    [ExtendObjectType(Name = "Query")]
    public class ReservationResolver
    {
        public IList<Reservation> GetAllReservations([Service] IReservationService reservationService)
        {
            return reservationService.GetReservationsAsync().Result;
        }

        public async Task<Reservation> GetReservation([Service] IReservationService reservationService, long id)
        {
            return await reservationService.GetReservationByIdAsync(id);
        }
        
        public IList<Reservation> GetReservationsByVehicle([Service] IReservationService reservationService, long vehicleId)
        {
            return reservationService.GetReservationsByVehicleAsync(vehicleId).Result;
        }       
        public IList<Reservation> GetReservationsByCustomer([Service] IReservationService reservationService, long customerId)
        {
            return reservationService.GetReservationsByCustomerAsync(customerId).Result;
        }       
        public IList<Reservation> GetReservationsByEmployee([Service] IReservationService reservationService, long employeeId)
        {
            return reservationService.GetReservationsByEmployeeAsync(employeeId).Result;
        }
        
        
    }
}