using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data
{
    public interface IReservationService
    {
        Task<IList<Reservation>> GetReservationsAsync();
        Task<Reservation> GetReservationAsync(long id);

        Task<IList<Reservation>> GetReservationsByVehicleAsync(long id);

        Task<IList<Reservation>> GetReservationsByCustomerAsync(long id);
        Task<IList<Reservation>> GetReservationsByEmployeeAsync(long id);
        

        Task<Reservation> CreateReservationAsync(long vehicleId, long customerId, long employeeId, int securityDeposit,
            long dateCreated, long dateStart, long dateEnd, int allowedKm, float paymentAmount, long billDate, bool isPaid);

        Task<Reservation> UpdateReservationAsync(Reservation reservation);
        Task<bool> DeleteReservationAsync(long id);
    }
}