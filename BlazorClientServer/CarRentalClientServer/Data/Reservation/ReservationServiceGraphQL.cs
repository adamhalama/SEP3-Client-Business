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
    public class ReservationServiceGraphQL : IReservationService
    {
        private GraphQLHttpClient graphQlClient
            = new("https://localhost:5010/graphql", new NewtonsoftJsonSerializer());
        
        public async Task<IList<Reservation>> GetReservationsAsync()
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query
                AllReservations
                {
                    allReservations
                    {
                        id
                        vehicle
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
                        customer
                        {
                          id
                          name
                          email
                          address
                          licenceNumber
                        }
                        employee
                        {
                          id
                          name
                          email
                          clearanceLevel
                        }
                        securityDeposit
                        dateCreated
                        dateStart
                        dateEnd
                        allowedKm
                        paymentAmount
                        billDate
                        isPaid
                    }
                }",
                OperationName = "AllReservations"
            };

            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<AllReservationsResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.AllReservations;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        
        public async Task<IList<Reservation>> GetReservationsByVehicleAsync(long id)
        {
            var request = new GraphQLRequest
            {
                //maybe change the query to include all parameters
                Query = @"
                query
                ReservationsByVehicle($id: Long!)
                {
                    reservationsByVehicle(id: $id)
                    {
                        id
                        vehicle
                        {
                          id
                        }
                        customer
                        {
                          id
                          name
                          email
                          address
                          licenceNumber
                        }
                        employee
                        {
                          id
                          name
                          email
                          clearanceLevel
                        }
                        securityDeposit
                        dateCreated
                        dateStart
                        dateEnd
                        allowedKm
                        paymentAmount
                        billDate
                        isPaid
                    }
                }",
                OperationName = "ReservationsByVehicle",
                Variables = new {id = id}
            };

            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<ReservationsByVehicleResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.ReservationsByVehicle;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        
        public async Task<IList<Reservation>> GetReservationsByCustomerAsync(long id)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query
                ReservationsByCustomer($id: Long!)
                {
                    reservationsByCustomer(id: $id)
                    {
                    id
                    vehicle
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
                    customer
                    {
                      id
                      name
                      email
                      address
                      licenceNumber
                    }
                    employee
                    {
                      id
                      name
                      email
                      clearanceLevel
                    }
                    securityDeposit
                    dateCreated
                    dateStart
                    dateEnd
                    allowedKm
                    paymentAmount
                    billDate
                    isPaid
                  }
                }",
                OperationName = "ReservationsByCustomer",
                Variables = new {id = id}
            };

            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<ReservationsByCustomerResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.ReservationsByCustomer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<IList<Reservation>> GetReservationsByEmployeeAsync(long id)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query
                reservationsByEmployee($id: Long!)
                {
                    ReservationsByEmployee(id: $id)
                    {
                    id
                    vehicle
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
                    customer
                    {
                      id
                      name
                      email
                      address
                      licenceNumber
                    }
                    employee
                    {
                      id
                      name
                      email
                      clearanceLevel
                    }
                    securityDeposit
                    dateCreated
                    dateStart
                    dateEnd
                    allowedKm
                    paymentAmount
                    billDate
                    isPaid
                  }
                }",
                OperationName = "ReservationsByEmployee",
                Variables = new {id = id}
            };

            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<ReservationsByEmployeeResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.ReservationsByEmployee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        
        public async Task<Reservation> GetReservationAsync(long id)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query
                Reservation($id : Long!)
                {
                    reservation(id: $id)
                    {
                        id
                        vehicle
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
                        customer
                        {
                          id
                          name
                          email
                          address
                          licenceNumber
                        }
                        employee
                        {
                          id
                          name
                          email
                          clearanceLevel
                        }
                        securityDeposit
                        dateCreated
                        dateStart
                        dateEnd
                        allowedKm
                        paymentAmount
                        billDate
                        isPaid
                  }
                }
            ",
                OperationName = "Reservation",
                Variables = new {id = id}
            };

            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<ReservationResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.Reservation;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        
        public async Task<Reservation> CreateReservationAsync(long vehicleId, long customerId, long employeeId,
            int securityDeposit,
            long dateCreated, long dateStart, long dateEnd, int allowedKm, float paymentAmount, long billDate,
            bool isPaid)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                CreateReservation($reservationInput : ReservationInput)
                {
                  createReservation(reservation: $reservationInput)
                  {
                    id
                    vehicle
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
                    customer
                    {
                      id
                      name
                      email
                      address
                      licenceNumber
                    }
                    employee
                    {
                      id
                      name
                      email
                      clearanceLevel
                    }
                    securityDeposit
                    dateCreated
                    dateStart
                    dateEnd
                    allowedKm
                    paymentAmount
                    billDate
                    isPaid
                  }
                }",
                OperationName = "CreateReservation",
                Variables = new
                {
                    reservationInput = new Reservation
                    {
                        Id = -1,
                        Vehicle = new Vehicle() {
                            Id = vehicleId,
                            Name = "null",
                            Type = "null",
                            PricePerDay = -1,
                            SeatsCount = -1,
                            IsAutomatic = false,
                            PowerKw = -1,
                            FuelType = "null",
                            Deposit = -1
                            
                        },
                        Customer = new Customer() {
                            Id = customerId,
                            Name = "null",
                            Email = "null@null.null",
                            Password = "null",
                            Address = "null",
                            LicenceNumber = "null"
                        },
                        Employee = new Employee() {
                            Id = employeeId,
                            Name = "null",
                            Email = "null@null.null",
                            Password = "null",
                            ClearanceLevel = -1
                            
                        },
                        SecurityDeposit = securityDeposit,
                        DateCreated = dateCreated,
                        DateStart = dateStart,
                        DateEnd = dateEnd,
                        AllowedKm = allowedKm,
                        PaymentAmount = paymentAmount,
                        BillDate = billDate,
                        IsPaid = isPaid
                    }
                }
            };
            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<CreateReservationResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.CreateReservation;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                UpdateReservation($reservationInput : ReservationInput)
                {
                    updateReservation(reservation: $reservationInput)
                    {
                        id
                        vehicle
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
                        customer
                        {
                          id
                          name
                          email
                          address
                          licenceNumber
                        }
                        employee
                        {
                          id
                          name
                          email
                          clearanceLevel
                        }
                        securityDeposit
                        dateCreated
                        dateStart
                        dateEnd
                        allowedKm
                        paymentAmount
                        billDate
                        isPaid
                  }
                }",
                OperationName = "UpdateReservation",
                Variables = new
                {
                    reservationInput = reservation
                }
            };

            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<UpdateReservationResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.UpdateReservation;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<bool> DeleteReservationAsync(long id)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                DeleteReservation($id : Long!)
                {
                    deleteReservation(id : $id)
                    {
                        id
                    }
                }",
                OperationName = "DeleteReservation",
                Variables = new {id}
            };
            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<DeleteReservationResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.DeleteReservation != null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}