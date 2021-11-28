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
        private string uri = "http://localhost:8080/api";

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

        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/vehicles");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }

            string message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Vehicle>>(message);
            // return message;
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/vehicles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }

            var message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Vehicle>(message);
            // return message;
        }


        // method not using json to transfer
        public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            string vehicleAsJson = JsonSerializer.Serialize(vehicle);
            HttpContent content = new StringContent(vehicleAsJson,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage response = await client.PostAsync(uri + "/vehicles", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");

            string message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Vehicle>(message);
        }

        // method using JSON to transfer data
        /*public async Task<string> CreateVehicleAsync(string vehicle)
        {
            HttpContent content = new StringContent(vehicle,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/vehicles", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }

            string message = await response.Content.ReadAsStringAsync();
            return message;
        }*/

        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
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
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Vehicle>(message);
            }

            //todo maybe add a successful return
        }

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/vehicles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error, {response.StatusCode}, {response.ReasonPhrase}");
            }
            else
            {
                var isDeletedMap =
                    JsonSerializer.Deserialize<Dictionary<string, bool>>(response.Content.ReadAsStringAsync().Result);
                if (isDeletedMap == null)
                {
                    return false;
                }

                return isDeletedMap["deleted"];
            }
        }
    }
}