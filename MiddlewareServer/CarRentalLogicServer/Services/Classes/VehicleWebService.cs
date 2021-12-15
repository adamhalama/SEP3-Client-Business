using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;
using CarRentalLogicServer.Services.Interfaces;
using HotChocolate;
using IHttpClientFactory = CarRentalLogicServer.Factories.IHttpClientFactory;

namespace CarRentalLogicServer.Services.Classes
{ 
    public class VehicleWebService : IVehicleService
    {
        private string uri;
        private readonly HttpClient client;

        public VehicleWebService([Service] IHttpClientFactory clientFactory)
        {
            client = clientFactory.GetHttpClient();
            uri = clientFactory.GetUri();
        }
        
        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/vehicles");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Vehicle>>(message);
            // return message;
        }

        public async Task<List<Vehicle>> GetAvailableVehiclesAsync(long startDate, long endDate)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/vehicles/available/startDate={startDate}&endDate={endDate}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Vehicle>>(message);
        }

        public async Task<Vehicle> GetVehicleByIdAsync(long id)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/vehicles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
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
                throw new Exception(response.ReasonPhrase);

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
                throw new Exception(response.ReasonPhrase);
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
            //send Http request, receiving and putting it into a response 
            HttpResponseMessage response = await client.PutAsync($"{uri}/vehicles/{vehicle.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new IndexOutOfRangeException($"{response.StatusCode}");
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Vehicle>(message);
            }
        }

        public async Task<Vehicle> DeleteVehicleAsync(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/vehicles/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new IndexOutOfRangeException($"{response.StatusCode}");
            }
            else
            {
                /*var isDeletedMap =
                    JsonSerializer.Deserialize<Dictionary<string, bool>>(response.Content.ReadAsStringAsync().Result);
                // the server sends a map with a deleted keyword and a bool saying if the delete was successful or not
                return isDeletedMap != null && isDeletedMap["deleted"];*/
                var deletedVehicle = JsonSerializer.Deserialize<Vehicle>(response.Content.ReadAsStringAsync().Result);
                return deletedVehicle;
            }
        }
    }
}