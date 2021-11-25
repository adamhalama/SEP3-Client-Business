using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalLogicServer.Models.REST;

namespace CarRentalLogicServer.APIConsumer
{
    public class WebCarService : ICarService
    {
        private string uri = "http://localhost:8080";

        private readonly HttpClient client;

        private IList<Car> cars;

        public WebCarService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            client = new HttpClient(clientHandler);
        }

        public async Task<IList<Car>> GetCarsAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/cars");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }

            string message = await response.Content.ReadAsStringAsync();
            List<Car> result = JsonSerializer.Deserialize<List<Car>>(message);
            return result;
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            string carAsJson = JsonSerializer.Serialize(car);
            HttpContent content = new StringContent(carAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/cars", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }

            string message = await response.Content.ReadAsStringAsync();
            Car result = JsonSerializer.Deserialize<Car>(message);
            return result;
        }

        //  VEHICLES
        
        public async Task<IList<Vehicle>> GetVehiclesAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/vehicles");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }

            string message = await response.Content.ReadAsStringAsync();
            List<Vehicle> result = JsonSerializer.Deserialize<List<Vehicle>>(message);
            return result;
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/vehicles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }

            var message = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Vehicle>(message);
            return result;
        }


        public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            string carAsJson = JsonSerializer.Serialize(vehicle);
            HttpContent content = new StringContent(carAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/vehicles", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }

            string message = await response.Content.ReadAsStringAsync();
            Vehicle result = JsonSerializer.Deserialize<Vehicle>(message);
            return result;
        }

        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            string vehicleAsJson = JsonSerializer.Serialize(vehicle);
            HttpContent content = new StringContent(vehicleAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PutAsync($"{uri}/vehicles/{vehicle.Id}", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.StatusCode};{response.ReasonPhrase}");
            }

            //todo maybe add a successful return
        }

        public async Task DeleteVehicleAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/vehicles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
        }
    }
}