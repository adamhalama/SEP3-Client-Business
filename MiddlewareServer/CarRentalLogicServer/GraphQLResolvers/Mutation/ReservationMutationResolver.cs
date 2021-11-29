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
            return await reservationService.CreateReservationAsync(reservation);
        }

        public async Task<Reservation> UpdateReservation([Service] IReservationService reservationService, Reservation reservation)
        {
            return await reservationService.UpdateReservationAsync(reservation);
        }

        public async Task<bool> DeleteReservation([Service] IReservationService reservationService, int id)
        {
            return await reservationService.DeleteReservationAsync(id);
        }
    }
}