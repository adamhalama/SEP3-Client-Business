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


        public async Task<IList<Vehicle>> GetVehiclesAsync()
        {
            string query = @"
            query
            AllVehicles
            {
                allVehicles
            }
            ";

            var request = MakeGraphQLRequest(query, "AllVehicles");


            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));

                var graphQLResponse = await graphQlClient.SendQueryAsync<AllVehiclesResponse>(request);
                //showing serialized response
                Console.WriteLine("serialised response:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse,
                    new JsonSerializerOptions {WriteIndented = true}));

                return JsonSerializer.Deserialize<IList<Vehicle>>(graphQLResponse.Data.AllVehicles);
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

        public async Task<Vehicle> GetVehicleAsync(int id)
        {
            string query = @"
            query
            Vehicle($id : Int!)
            {
                vehicle(id: $id)
            }
            ";
            var variables = new {id = id};
            var request = MakeGraphQLRequest(query, "Vehicle", variables);

            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions { WriteIndented = true }));

                var graphQLResponse = await graphQlClient.SendQueryAsync<VehicleResponse>(request);
                //showing serialized response
                Console.WriteLine("serialised response:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse,
                    new JsonSerializerOptions {WriteIndented = true}));

                return JsonSerializer.Deserialize<Vehicle>(graphQLResponse.Data.Vehicle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                    Console.WriteLine(e.InnerException.Message);
                
                throw;
            }
        }

        public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            vehicle.Id = -1; //making sure that there is some id, and is invalid
            string query = @"
            mutation
            CreateVehicle($vehicleInput : string!)
            {
                createVehicle(vehicle: $vehicleInput)
            }  
            ";
            var variables = new
            {
                vehicleInput = JsonSerializer.Serialize(vehicle)
            };

            var request = MakeGraphQLRequest(query, "CreateVehicle", variables);
            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));

                var graphQLResponse = await graphQlClient.SendQueryAsync<CreateVehicleResponse>(request);
                //showing serialized response
                Console.WriteLine("serialised response:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse,
                    new JsonSerializerOptions {WriteIndented = true}));
                return JsonSerializer.Deserialize<Vehicle>(graphQLResponse.Data.CreateVehicle);
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

        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
        {
            string query = @"
            mutation
            UpdateVehicle($vehicleInput : string, $id : Int)
            {
                updateVehicle(vehicle: $vehicleInput, id : $id)
            }
            ";
            var variables = new { vehicleInput = JsonSerializer.Serialize(vehicle), vehicle.Id };
            var request = MakeGraphQLRequest(query, "UpdateVehicle", variables);
            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions { WriteIndented = true }));

                var graphQLResponse = await graphQlClient.SendQueryAsync<UpdateVehicleResponse>(request);
                //showing serialized response
                Console.WriteLine("serialised response:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse,
                    new JsonSerializerOptions {WriteIndented = true}));
                Console.WriteLine("serialised response v2:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse.Data.UpdateVehicle,
                    new JsonSerializerOptions {WriteIndented = true}));
                
                return JsonSerializer.Deserialize<Vehicle>(graphQLResponse.Data.UpdateVehicle);
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

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            
            string query = @"
            mutation
            DeleteVehicle($id : Int)
            {
                deleteVehicle(id : $id)
            }
            ";
            var variables = new { id };
            var request = MakeGraphQLRequest(query, "UpdateVehicle", variables);
            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions { WriteIndented = true }));

                var graphQLResponse = await graphQlClient.SendQueryAsync<DeleteVehicleResponse>(request);
                //showing serialized response
                Console.WriteLine("serialised response:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse,
                    new JsonSerializerOptions {WriteIndented = true}));
                Console.WriteLine("serialised response v2:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse.Data.DeleteVehicle,
                    new JsonSerializerOptions {WriteIndented = true}));
                
                return JsonSerializer.Deserialize<bool>(graphQLResponse.Data.DeleteVehicle);
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
            var request = new GraphQLRequest
            {
                Query = query,
                OperationName = operationName,
                Variables = variables
            };
            return request;
        }

        private static GraphQLRequest MakeGraphQLRequest(string query, string operationName)
        {
            var request = new GraphQLRequest
            {
                Query = query,
                OperationName = operationName
            };
            return request;
        }

        //legacy class not using Json
        /*public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            string query = @"
            mutation
            CreateVehicle($vehicleInput : VehicleInput)
            {
                createVehicle(vehicle: $vehicleInput)
                {
                    id
                    name
                    type
                    pricePerDay
                    seatsCount
                    isAutomatic
                    powerKw
                    fuelType
                    deposit
                }
            }
            ";

            var variables = new
            {
                vehicleInput = new Vehicle
                {
                    Id = vehicle.Id,
                    Name = vehicle.Name,
                    Type = vehicle.Type,
                    PricePerDay = vehicle.PricePerDay,
                    SeatsCount = vehicle.SeatsCount,
                    IsAutomatic = vehicle.IsAutomatic,
                    PowerKw = vehicle.PowerKw,
                    FuelType = vehicle.FuelType,
                    Deposit = vehicle.Deposit
                }
            };

            var request = MakeGraphQLRequest(query, "CreateVehicle", variables);

            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));

                var graphQLResponse = await graphQlClient.SendQueryAsync<CreateVehicleResponse>(request);

                //showing serialized response
                Console.WriteLine("serialised response:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    }));

                return graphQLResponse.Data.CreateVehicle;
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
        */
    }
}