using System;
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
    public class LoginWebService : ILoginService
    {
        private string uri;

        private readonly HttpClient client;

        public LoginWebService([Service] IHttpClientFactory clientFactory)
        {
            client = clientFactory.GetHttpClient();
            uri = clientFactory.GetUri();
        }
        public async Task<UserLogin> LoginAsync(UserLogin credentials)
        {
            string credentialsAsJson = JsonSerializer.Serialize(credentials);
            HttpContent content = new StringContent(credentialsAsJson,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage response = await client.PostAsync(uri + "/login", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode + "");

            string message = await response.Content.ReadAsStringAsync();
            var userLogin = JsonSerializer.Deserialize<UserLogin>(message);
            return userLogin;
        }
    }
}