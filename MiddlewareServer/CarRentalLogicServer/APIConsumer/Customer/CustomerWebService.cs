using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;
using HotChocolate;
using IHttpClientFactory = CarRentalLogicServer.APIConsumer.ClientFactory.IHttpClientFactory;

namespace CarRentalLogicServer.APIConsumer
{
    //todo check the methods, it was copied ctrlR
    public class CustomerWebService : ICustomerService
    {
        private string uri = "http://localhost:8080/api";

        private readonly HttpClient client;

        public CustomerWebService([Service] IHttpClientFactory clientFactory)
        {
            client = clientFactory.GetHttpClient();
        }
        
        public async Task<List<Customer>> GetCustomersAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/customers");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Customer>>(message);
            // return message;
        }

        public async Task<Customer> GetCustomerByIdAsync(long id)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/customers/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            var message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Customer>(message);
            // return message;
        }


        // method not using json to transfer
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            string customerAsJson = JsonSerializer.Serialize(customer);
            HttpContent content = new StringContent(customerAsJson,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage response = await client.PostAsync(uri + "/customers", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ReasonPhrase);

            string message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Customer>(message);
        }

        // method using JSON to transfer data
        /*public async Task<string> CreateCustomerAsync(string customer)
        {
            HttpContent content = new StringContent(customer,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/customers", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string message = await response.Content.ReadAsStringAsync();
            return message;
        }*/

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            string customerAsJson = JsonSerializer.Serialize(customer);
            HttpContent content = new StringContent(customerAsJson,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage response = await client.PutAsync($"{uri}/customers/{customer.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Customer>(message);
        }

        public async Task<Customer> DeleteCustomerAsync(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/customers/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            var deletedCustomer =
                JsonSerializer.Deserialize<Customer>(response.Content.ReadAsStringAsync().Result);
            return deletedCustomer;
        }
    }
}