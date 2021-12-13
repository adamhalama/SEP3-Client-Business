using System.Collections.Generic;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data.Responses
{
    public class AllReservationsResponse
    {
        public List<Reservation> AllReservations { get; set; }
    }
}