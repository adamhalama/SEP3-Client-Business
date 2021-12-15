using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;

namespace CarRentalLogicServer.Services.Interfaces
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetReservationsByVehicleAsync(long vehicleId);
        Task<List<Reservation>> GetReservationsByCustomerAsync(long customerId);
        Task<List<Reservation>> GetReservationsByEmployeeAsync(long employeeId);
        
        Task<List<Reservation>> GetReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(long id);
        Task<Reservation> CreateReservationAsync(Reservation reservation);
        Task<Reservation> UpdateReservationAsync(Reservation reservation);
        Task<Reservation> DeleteReservationAsync(long id);
    }
}