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
                Console.WriteLine(vehicleService.GetVehicleAsync(1).Result.Name);
                var vehicles = vehicleService.GetVehiclesAsync().Result;
                vehicleService.CreateVehicleAsync(
                    new Vehicle
                    {
                        Id = 1,
                        Name = "jebo z lesa",
                        Type = "jebovsky",
                        PricePerDay = 420,
                        SeatsCount = 2,
                        IsAutomatic = false,
                        PowerKw = 420,
                        FuelType = "not electric",
                        Deposit = 3
                    }
                );
            } while (Console.ReadLine() != "x");
            
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}