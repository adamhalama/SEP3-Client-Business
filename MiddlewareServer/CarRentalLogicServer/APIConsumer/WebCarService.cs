using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;

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
    }
}