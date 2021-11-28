using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data
{
    public abstract class ReservationServiceGraphQL : IReservationService
    {
        public Task<IList<Reservation>> GetReservationsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Reservation> GetReservationAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Reservation> CreateReservationAsync(Reservation reservation)
        {
            throw new System.NotImplementedException();
        }

        public Task<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteReservationAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}