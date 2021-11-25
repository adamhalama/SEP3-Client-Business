using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using CarRentalLogicServer.Models.REST;

namespace CarRentalLogicServer.APIConsumer
{
    public class WebVehicleService
    {
        private string uri = "http://localhost:8080"; 
        
        // private string uri = "http://jsonplaceholder.typicode.com";
        private readonly HttpClient client;

        private IList<Vehicle> vehicles;

        public WebVehicleService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => {
                return true;
            };
            
            client = new HttpClient(clientHandler);
        }
    }
}