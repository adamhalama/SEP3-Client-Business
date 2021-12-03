using System.Collections.Generic;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data.Responses
{
    public class ReservationsByEmployeeResponse
    {
        public List<Reservation> ReservationsByEmployee { get; set; }
    }
}