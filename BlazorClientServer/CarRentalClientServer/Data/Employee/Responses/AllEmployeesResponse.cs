using System.Collections.Generic;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data.Responses
{
    public class AllEmployeesResponse
    {
        public List<Employee> AllEmployees { get; set; }
    }
}