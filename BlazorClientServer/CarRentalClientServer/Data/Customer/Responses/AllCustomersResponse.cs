using System.Collections.Generic;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data.Responses
{
    public class AllCustomersResponse
    {
        public List<Customer> AllCustomers { get; set; }
    }
}