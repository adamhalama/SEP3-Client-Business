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
        
        // private string uri = "http://jsonplaceholder.typicode.com";
        private readonly HttpClient client;

        private IList<Car> cars;
        
        public WebCarService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => {
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

    }
}