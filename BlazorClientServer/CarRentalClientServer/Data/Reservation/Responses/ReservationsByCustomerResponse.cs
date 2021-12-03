using System.Collections.Generic;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data.Responses
{
    public class ReservationsByCustomerResponse
    {
        public List<Reservation> ReservationsByCustomer { get; set; }
    }
}