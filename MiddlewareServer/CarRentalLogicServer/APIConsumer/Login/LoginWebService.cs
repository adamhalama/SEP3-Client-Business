using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;
using HotChocolate;
using IHttpClientFactory = CarRentalLogicServer.APIConsumer.ClientFactory.IHttpClientFactory;

namespace CarRentalLogicServer.APIConsumer.Login
{
    public class LoginWebService : ILoginService
    {
        private string uri = "http://localhost:8080/api";

        private readonly HttpClient client;

        public LoginWebService([Service] IHttpClientFactory clientFactory)
        {
            client = clientFactory.GetHttpClient();
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