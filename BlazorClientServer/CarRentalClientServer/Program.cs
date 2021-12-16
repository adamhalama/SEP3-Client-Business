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
        public static async Task Main(string[] args)
        {
            /*
            do
            {
    
                
                try
                {
                    // Console.WriteLine(vehicleService.GetVehicleAsync(1).Result.ToString());
                    // var vehicles = vehicleService.GetVehiclesAsync().Result;
                    // foreach (var vehicle in vehicles)
                    // {
                    //     Console.WriteLine(vehicle.ToString());
                    // }
                    Console.WriteLine(("User"));
                    employeeService.CreateEmployeeAsync("Test", "test@email.com", "test", 5);

                    // Console.WriteLine("create vehicles");
                    // vehicleService.CreateVehicleAsync(
                    //     "BMW M2 Competition 3.0", "Coupe", 300, 
                    //     4, false, 300, "Petrol", 3000);
                    // vehicleService.CreateVehicleAsync(
                    //     "BMW M2 Competition 3.0", "Coupe", 300, 
                    //     4, false, 300, "Petrol", 3000);
                    // vehicleService.CreateVehicleAsync(
                    //     "BMW M2 Competition 3.0", "Coupe", 300, 
                    //     4, false, 300, "Petrol", 3000);
                    // vehicleService.CreateVehicleAsync(
                    //     "Updated jebo", "Coupe", 300,
                    //     4, false, 300, "Petrol", 3000);

                    // Console.WriteLine("Customer");
                    // customerService.CreateCustomerAsync("jebo", "jebnuty@jano.sk", "123", "V lese", "123XX");
                    // Console.WriteLine("Employee");
                    // await employeeService.CreateEmployeeAsync("admin", "admin@bruh.com", "admin", 1);

                    // Console.WriteLine("reservation");
                    //await reservationService.CreateReservationAsync(1, 1, 1, 1000,
                    //    1639404928, 1639491328, 1639656928, 1000, 1200, 1639408528, true);

                    // vehicleService.UpdateVehicleAsync(new Vehicle(10, "Updated jebo", "Coupe", 300, 4, false, 300, "Petrol", 3000));

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
            */
            try
            {
                IEmployeeService employeeService = new EmployeeServiceGraphQL();
                Console.WriteLine("Creating default Employee: admin@bruh.com admin");
                await employeeService.CreateEmployeeAsync("admin", "admin@bruh.com", "admin", 2);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("the account has already been created");
            }
            
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
