using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;

namespace CarRentalLogicServer.APIConsumer
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetReservationsByVehicleAsync(long vehicleId);
        Task<List<Reservation>> GetReservationsByCustomerAsync(long customerId);
        Task<List<Reservation>> GetReservationsByEmployeeAsync(long employeeId);
        
        Task<List<Reservation>> GetReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(int id);
        Task<Reservation> CreateReservationAsync(Reservation reservation);
        Task<Reservation> UpdateReservationAsync(Reservation reservation);
        Task<bool> DeleteReservationAsync(int id);
    }
}