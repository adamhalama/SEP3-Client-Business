using System.Collections.Generic;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data.Responses
{
    public class AllVehiclesResponse
    {
        public List<Vehicle> AllVehicles { get; set; }
        
        /*public class CarContent
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Model { get; set; }
        }*/
    }
}