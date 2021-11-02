using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data
{
    public class CarServiceSockets : ICarService
    {
        // private string message = "Hello world";
        static private string serverIP = "127.0.0.1";

        private NetworkStream stream;
        private TcpClient client;

        private String responseData;

        public CarServiceSockets()
        {
        }

        public void StartClient()
        {
            throw new NotImplementedException();
        }

        public string SendMessage(String message)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = 13000;
                client = new TcpClient(serverIP, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                stream = client.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Close everything.
                client.Close();
            }
            return responseData;
        }




        public async Task<IList<Car>> GetCarsAsync()
        {
            var jsonString = SendMessage("GetCars");
            
            List<Car> result = JsonSerializer.Deserialize<List<Car>>(jsonString);
            return result;
        }

        public void AddCar(Car car)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCar(int carId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCar(Car car)
        {
            throw new System.NotImplementedException();
        }

        public Car GetSpcificCar(int carId)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Adult
    {
    }
}