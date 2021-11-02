using System;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.ClientServerHost;

namespace CarRentalLogicServer
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                // APIConsumer();

                StartSocketServer();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void StartSocketServer()
        {
            var server = new Server();
            server.Listen();
        }

        private static void APIConsumer()
        {
            Console.WriteLine("press escape to exit, press anything else to continue and fech again");


            ICarService carService = new WebCarService();
            var result = carService.GetCarsAsync().Result;
            foreach (var car in result)
            {
                Console.WriteLine(car.Model + " - " + car.Name);
            }
        }
    }
}