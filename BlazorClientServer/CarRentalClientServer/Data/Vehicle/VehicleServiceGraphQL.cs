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
            = new("https://localhost:5010/graphql", new NewtonsoftJsonSerializer());

        public async Task<IList<Vehicle>> GetVehiclesAsync()
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query
                AllVehicles
                {
                    allVehicles
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
                }",
                OperationName = "AllVehicles"
            };

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

                return graphQLResponse.Data.AllVehicles;
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
            var request = new GraphQLRequest
            {
                Query = @"
                query
                Vehicle($id : Int!)
                {
                    vehicle(id: $id)
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
            ",
                OperationName = "Vehicle",
                Variables = new {id = id}
            };

            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions {WriteIndented = true}));

                var graphQLResponse = await graphQlClient.SendQueryAsync<VehicleResponse>(request);
                //showing serialized response
                Console.WriteLine("serialised response:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse,
                    new JsonSerializerOptions {WriteIndented = true}));
                return graphQLResponse.Data.Vehicle;
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
        public async Task<Vehicle> CreateVehicleAsync(string name, string type, int pricePerDay,
            int seatsCount, bool isAutomatic, int powerKw, string fuelType, int deposit)
        {
            var request = new GraphQLRequest
            {
                Query = @"
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
            }",
                OperationName = "CreateVehicle",
                Variables = new
                {
                    vehicleInput = new Vehicle
                    {
                        Id = -1,
                        Name = name,
                        Type = type,
                        PricePerDay = pricePerDay,
                        SeatsCount = seatsCount,
                        IsAutomatic = isAutomatic,
                        PowerKw = powerKw,
                        FuelType = fuelType,
                        Deposit = deposit
                    }
                }
            };
            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions {WriteIndented = true}));
                var graphQLResponse = await graphQlClient.SendQueryAsync<CreateVehicleResponse>(request);
                //showing serialized response
                Console.WriteLine("serialised response:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse,
                    new JsonSerializerOptions {WriteIndented = true}));
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

        //method using json
        /*public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
        {
            vehicle.Id = -1; //making sure that there is some id, and is invalid
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                CreateVehicle($vehicleInput : string!)
                {
                    createVehicle(vehicle: $vehicleInput)
                }
            ",
            OperationName = "CreateVehicle",
            Variables = JsonSerializer.Serialize(vehicle)
            };

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
        */

        public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                UpdateVehicle($vehicleInput : VehicleInput)
                {
                    updateVehicle(vehicle: $vehicleInput)
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
                }",
                OperationName = "CreateVehicle",
                Variables = new
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
                }
            };

            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions {WriteIndented = true}));

                var graphQLResponse = await graphQlClient.SendQueryAsync<UpdateVehicleResponse>(request);
                //showing serialized response
                Console.WriteLine("serialised response:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse,
                    new JsonSerializerOptions {WriteIndented = true}));
                Console.WriteLine("serialised response v2:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse.Data.UpdateVehicle,
                    new JsonSerializerOptions {WriteIndented = true}));
                return graphQLResponse.Data.UpdateVehicle;
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
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                DeleteVehicle($id : Int)
                {
                    deleteVehicle(id : $id)
                }",
                OperationName = "UpdateVehicle",
                Variables =  new { id }
            };
            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions {WriteIndented = true}));

                var graphQLResponse = await graphQlClient.SendQueryAsync<DeleteVehicleResponse>(request);
                //showing serialized response
                Console.WriteLine("serialised response:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse,
                    new JsonSerializerOptions {WriteIndented = true}));
                Console.WriteLine("serialised response v2:");
                Console.WriteLine(JsonSerializer.Serialize(graphQLResponse.Data.DeleteVehicle,
                    new JsonSerializerOptions {WriteIndented = true}));
                
                return graphQLResponse.Data.DeleteVehicle;
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
    }
}