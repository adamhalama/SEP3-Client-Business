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

        public async Task<Reservation> GetReservation([Service] IReservationService reservationService, int id)
        {
            return await reservationService.GetReservationByIdAsync(id);
        }
    }
}