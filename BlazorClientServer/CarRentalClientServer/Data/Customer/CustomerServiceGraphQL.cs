using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalClientServer.Data.Responses;
using CarRentalClientServer.Models;
using CarRentalClientServer.Utilities;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace CarRentalClientServer.Data
{
    public class CustomerServiceGraphQL : ICustomerService
    {
        private GraphQLHttpClient graphQlClient
            = new("https://localhost:5010/graphql", new NewtonsoftJsonSerializer());

        public async Task<IList<Customer>> GetCustomersAsync()
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query
                AllCustomers
                {
                    allCustomers
                    {
                        id
                        name
                        email
                        address
                        licenceNumber
                    }
                }",
                OperationName = "AllCustomers"
            };

            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<AllCustomersResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.AllCustomers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine(e.InnerException.Message);
                }

                throw;
            }
        }

        public async Task<Customer> GetCustomerAsync(long id)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query
                Customer($id : Long!)
                {
                    customer(id: $id)
                    {
                        id
                        name
                        email
                        address
                        licenceNumber
                    }
                }
            ",
                OperationName = "Customer",
                Variables = new {id = id}
            };

            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions {WriteIndented = true}));

                var graphQLResponse = await graphQlClient.SendQueryAsync<CustomerResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.Customer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                    Console.WriteLine(e.InnerException.Message);

                throw;
            }
        }

        //method not using Json
        public async Task<Customer> CreateCustomerAsync(string name, string email, string password, string address,
            string licenceNumber)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation CreateCustomer($customerInput: CustomerInput) 
                {
                    createCustomer(customer: $customerInput) 
                    {
                        id
                        name
                        email
                        address
                        licenceNumber
                    }
                }",
                OperationName = "CreateCustomer",
                Variables = new
                {
                    customerInput = new Customer
                    {
                        Id = -1,
                        Name = name,
                        Email = email,
                        Password = password,
                        Address = address,
                        LicenceNumber = licenceNumber
                    }
                }
            };
            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<CreateCustomerResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.CreateCustomer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                UpdateCustomer($customerInput : CustomerInput)
                {
                    updateCustomer(customer: $customerInput)
                    {
                        id
                        name
                        email
                        address
                        licenceNumber
                    }
                }",
                OperationName = "UpdateCustomer",
                Variables = new
                {
                    customerInput = customer
                }
            };

            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<UpdateCustomerResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.UpdateCustomer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<bool> DeleteCustomerAsync(long id)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                DeleteCustomer($id : Long!)
                {
                    deleteCustomer(id : $id)
                    {
                        id
                        name
                        email
                        address
                        licenceNumber
                    }
                }",
                OperationName = "DeleteCustomer",
                Variables = new {id}
            };
            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<DeleteCustomerResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.DeleteCustomer != null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}