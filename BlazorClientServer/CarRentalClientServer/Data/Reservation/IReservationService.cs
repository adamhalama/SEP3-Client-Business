using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data
{
    public interface IReservationService
    {
        Task<IList<Models.Reservation>> GetReservationsAsync();
        Task<Models.Reservation> GetReservationAsync(int id);
        Task<Models.Reservation> CreateReservationAsync(Reservation reservation);
        Task<Models.Reservation> UpdateReservationAsync(Reservation reservation);
        Task<bool> DeleteReservationAsync(int id);
    }
}