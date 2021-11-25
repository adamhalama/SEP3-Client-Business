using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using CarRentalClientServer.Data.Responses;
using CarRentalClientServer.Models;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace CarRentalClientServer.Data
{
    public class VehicleServiceGraphQL : IVehicleService
    {
        private GraphQLHttpClient graphQlClient
            = new GraphQLHttpClient("https://localhost:5010/graphql", new NewtonsoftJsonSerializer());

        public string SendMessage(string message)
        {
            throw new System.NotImplementedException();
        }

        //todo rename to VEHICLE
        public async Task<IList<Vehicle>> GetCarsAsync()
        {
            string query = @"
            query
            AllCars
            {
                allCars
                {
                    id
                    name
                    model
                }
            }
            ";

            var variables = new
            {
                id = 1,
                name = "Jebo"
            };

            var request = MakeGraphQLRequest(query, "AllCars");


            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));
                
                var graphQLResponse = await graphQlClient.SendQueryAsync<AllCarsResponse>(request);
                
                //showing serialized response
                Console.WriteLine("serialised response:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));

                return graphQLResponse.Data.AllCars;
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

        private static GraphQLRequest MakeGraphQLRequest(string query, string operationName, object variables)
        {
            GraphQLRequest request;
            request = new GraphQLRequest
            {
                Query = query,
                OperationName = operationName,
                Variables = variables
            };
            return request;
        }

        private static GraphQLRequest MakeGraphQLRequest(string query, string operationName)
        {
            GraphQLRequest request;
            request = new GraphQLRequest
            {
                Query = query,
                OperationName = operationName
            };
            return request;
        }

        public Vehicle AddCar(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCar(int carId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCar(Vehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public Vehicle GetSpcificCar(int carId)
        {
            throw new System.NotImplementedException();
        }
    }
}