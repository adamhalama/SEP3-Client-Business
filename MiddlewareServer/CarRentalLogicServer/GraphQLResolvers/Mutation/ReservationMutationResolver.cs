using System;
using System.Threading.Tasks;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Mutation
{
    // class containing mutation resolvers for updating data
    [ExtendObjectType(Name = "Mutation")]
    public class ReservationMutationResolver
    {
        public async Task<Reservation> CreateReservation([Service] IReservationService reservationService, Reservation reservation)
        {
            try
            {
                return await reservationService.CreateReservationAsync(reservation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Reservation> UpdateReservation([Service] IReservationService reservationService, Reservation reservation)
        {
            try
            {
                return await reservationService.UpdateReservationAsync(reservation);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Reservation> DeleteReservation([Service] IReservationService reservationService, long id)
        {
            try
            {
                return await reservationService.DeleteReservationAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        } 
    }
}