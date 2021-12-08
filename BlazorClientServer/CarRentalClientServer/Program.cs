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
            /*do
            {
                IVehicleService vehicleService = new VehicleServiceGraphQL();
                IEmployeeService employeeService = new EmployeeServiceGraphQL();
                ICustomerService customerService = new CustomerServiceGraphQL();
                IReservationService reservationService = new ReservationServiceGraphQL();
                
                try
                {
                    // Console.WriteLine(vehicleService.GetVehicleAsync(1).Result.ToString());
                    // var vehicles = vehicleService.GetVehiclesAsync().Result;
                    // foreach (var vehicle in vehicles)
                    // {
                    //     Console.WriteLine(vehicle.ToString());
                    // }
                    
                    
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

                    Console.WriteLine("reservation");
                    await reservationService.CreateReservationAsync(1, 1, 1, 1000,
                        1627870000, 1627870693, 1627879999, 1000, 1200, 1627870000, true);

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
            
            
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
