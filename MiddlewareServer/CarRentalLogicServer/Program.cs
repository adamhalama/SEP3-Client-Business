using System;
using CarRentalLogicServer.APIConsumer;

namespace CarRentalLogicServer
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("press escape to exit, press anything else to continue and fech again");
                
                
                ICarService carService = new WebCarService();
                var result = carService.GetCarsAsync().Result;
                foreach (var car in result)
                {
                    Console.WriteLine(car.Model + " - " + car.Name);
                }
                
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}