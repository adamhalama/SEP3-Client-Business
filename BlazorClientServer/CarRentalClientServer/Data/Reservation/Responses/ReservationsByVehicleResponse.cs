using System.Collections.Generic;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data.Responses
{
    public class ReservationsByVehicleResponse
    {
        public List<Reservation> ReservationsByVehicle { get; set; }
    }
}