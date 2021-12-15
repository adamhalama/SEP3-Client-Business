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
                var graphQLResponse 
                    = await graphQlClient.SendQueryAsync<AllVehiclesResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

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

        public async Task<Vehicle> GetVehicleAsync(long id)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query
                Vehicle($id : Long!)
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
                var graphQLResponse = await graphQlClient.SendQueryAsync<VehicleResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.Vehicle;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IList<Vehicle>> GetAvailableVehiclesAsync(long startDate, long endDate)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query
                AvailableVehicles($startDate : Long!, $endDate : Long!)
                {
                    availableVehicles(startDate : $startDate, endDate : $endDate)
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
                OperationName = "AvailableVehicles",
                Variables = new 
                    {
                        startDate = startDate, 
                        endDate = endDate
                    }
            };

            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<AvailableVehiclesResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.AvailableVehicles;
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
                var graphQLResponse = await graphQlClient.SendQueryAsync<CreateVehicleResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.CreateVehicle;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new Vehicle();
        }

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
                OperationName = "UpdateVehicle",
                Variables = new
                {
                    vehicleInput = vehicle
                }
            };

            try
            {
                var graphQLResponse 
                    = await graphQlClient.SendQueryAsync<UpdateVehicleResponse>(request);

                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.UpdateVehicle;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<bool> DeleteVehicleAsync(long id)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                DeleteVehicle($id : Long!)
                {
                    deleteVehicle(id : $id)
                    {
                        id
                        name
                    }
                }",
                OperationName = "DeleteVehicle",
                Variables = new {id}
            };
            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<DeleteVehicleResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.DeleteVehicle != null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
    }
}