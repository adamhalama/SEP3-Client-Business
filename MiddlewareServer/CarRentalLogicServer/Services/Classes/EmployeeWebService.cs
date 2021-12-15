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
    //todo check the methods, it was copied ctrlR
    public class EmployeeWebService : IEmployeeService
    {
        private string uri;

        private readonly HttpClient client;

        public EmployeeWebService([Service] IHttpClientFactory clientFactory)
        {
            client = clientFactory.GetHttpClient();
            uri = clientFactory.GetUri();
        }
        
        
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/employees");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Employee>>(message);
            // return message;
        }

        public async Task<Employee> GetEmployeeByIdAsync(long id)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/employees/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            var message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Employee>(message);
            // return message;
        }


        // method not using json to transfer
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            string employeeAsJson = JsonSerializer.Serialize(employee);
            HttpContent content = new StringContent(employeeAsJson,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage response = await client.PostAsync(uri + "/employees", content);
            if (!response.IsSuccessStatusCode)
                throw new Exception(response.ReasonPhrase);

            string message = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Employee>(message);
        }

        // method using JSON to transfer data
        /*public async Task<string> CreateEmployeeAsync(string employee)
        {
            HttpContent content = new StringContent(employee,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/employees", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string message = await response.Content.ReadAsStringAsync();
            return message;
        }*/

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            string employeeAsJson = JsonSerializer.Serialize(employee);
            HttpContent content = new StringContent(employeeAsJson,
                Encoding.UTF8,
                "application/json");
            
            HttpResponseMessage response = await client.PutAsync($"{uri}/employees/{employee.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.StatusCode.ToString());
            }
            else
            {
                string message = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Employee>(message);
            }

            //todo maybe add a successful return
        }

        public async Task<Employee> DeleteEmployeeAsync(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/employees/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }
            
            var deleteEmployee =
                JsonSerializer.Deserialize<Employee>(response.Content.ReadAsStringAsync().Result);
            return deleteEmployee;
        }
    }
}