using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRentalClientServer.Data;
using CarRentalClientServer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CarRentalClientServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            /*
            do
            {
                IVehicleService vehicleService = new VehicleServiceGraphQL();
                Console.WriteLine(vehicleService.GetVehicleAsync(1).Result.Name);
                var vehicles = vehicleService.GetVehiclesAsync().Result;
                vehicleService.CreateVehicleAsync(
                    "BMW M2 Competition 3.0", "Coupe", 300, 
                    4, false, 300, "Petrol", 3000);
            } while (Console.ReadLine() != "x");
            */
            
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}