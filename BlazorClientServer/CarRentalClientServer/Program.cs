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
            do
            {
                IVehicleService vehicleService = new VehicleServiceGraphQL();

                try
                {
                    // Console.WriteLine(vehicleService.GetVehicleAsync(1).Result.ToString());
                    /*var vehicles = vehicleService.GetVehiclesAsync().Result;
                    foreach (var vehicle in vehicles)
                    {
                        Console.WriteLine(vehicle.ToString());
                    }*/
                    /*vehicleService.CreateVehicleAsync(
                        "BMW M2 Competition 3.0", "Coupe", 300, 
                        4, false, 300, "Petrol", 3000);
                    vehicleService.CreateVehicleAsync(
                        "BMW M2 Competition 3.0", "Coupe", 300, 
                        4, false, 300, "Petrol", 3000);
                    vehicleService.CreateVehicleAsync(
                        "BMW M2 Competition 3.0", "Coupe", 300, 
                        4, false, 300, "Petrol", 3000);
                    vehicleService.CreateVehicleAsync(
                        "BMW M2 Competition 3.0", "Coupe", 300, 
                        4, false, 300, "Petrol", 3000);*/

                    /*vehicleService.UpdateVehicleAsync(new Vehicle(10, "Updated jebo", "Coupe", 300,
                        4, false, 300, "Petrol", 3000));*/

                    // Console.WriteLine(vehicleService.DeleteVehicleAsync(4).Result);
                    // Console.WriteLine(vehicleService.DeleteVehicleAsync(1).Result);
                    // Console.WriteLine(vehicleService.DeleteVehicleAsync(2).Result);
                    // Console.WriteLine(vehicleService.DeleteVehicleAsync(3).Result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            } while (Console.ReadLine() != "x");


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}