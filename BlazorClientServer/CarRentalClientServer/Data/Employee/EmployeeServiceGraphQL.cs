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
    public class EmployeeServiceGraphQL : IEmployeeService
    {
        private GraphQLHttpClient graphQlClient
            = new("https://localhost:5010/graphql", new NewtonsoftJsonSerializer());

        public async Task<IList<Employee>> GetEmployeesAsync()
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query
                AllEmployees
                {
                    allEmployees
                    {
                        id
                        name
                        email
                        clearanceLevel
                    }
                }",
                OperationName = "AllEmployees"
            };

            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<AllEmployeesResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.AllEmployees;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Employee> GetEmployeeAsync(long id)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                query
                Employee($id : Long!)
                {
                    employee(id: $id)
                    {
                        id
                        name
                        email
                        clearanceLevel
                    }
                }
            ",
                OperationName = "Employee",
                Variables = new {id = id}
            };

            try
            {
                //showing what was sent
                Console.WriteLine(JsonSerializer.Serialize(request,
                    new JsonSerializerOptions {WriteIndented = true}));

                var graphQLResponse = await graphQlClient.SendQueryAsync<EmployeeResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.Employee;
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
        public async Task<Employee> CreateEmployeeAsync(string name, string email, string password, int clearanceLevel)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation CreateEmployee($employeeInput: EmployeeInput)
                {
                    createEmployee(employee: $employeeInput)
                    {
                        id
                        name
                        email
                        password
                        clearanceLevel
                    }
                }",
                OperationName = "CreateEmployee",
                Variables = new
                {
                    employeeInput = new Employee
                    {
                        Id = -1,
                        Name = name,
                        Email = email,
                        Password = password,
                        ClearanceLevel = clearanceLevel
                    }
                }
            };
            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<CreateEmployeeResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.CreateEmployee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                UpdateEmployee($employeeInput : EmployeeInput)
                {
                    updateEmployee(employee: $employeeInput)
                    {
                        id
                        name
                        email
                        clearanceLevel
                    }
                }",
                OperationName = "UpdateEmployee",
                Variables = new
                {
                    employeeInput = employee
                }
            };

            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<UpdateEmployeeResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.UpdateEmployee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(long id)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                DeleteEmployee($id : Long!)
                {
                    deleteEmployee(id : $id)
                    {
                        id
                        name
                        email
                        clearanceLevel
                    }
                }",
                OperationName = "DeleteEmployee",
                Variables = new {id}
            };
            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<DeleteEmployeeResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.DeleteEmployee != null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}