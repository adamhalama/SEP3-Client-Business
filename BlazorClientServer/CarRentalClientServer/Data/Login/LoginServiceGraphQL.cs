using System;
using System.Net;
using System.Threading.Tasks;
using CarRentalClientServer.Data.Responses;
using CarRentalClientServer.Models;
using CarRentalClientServer.Utilities;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace CarRentalClientServer.Data
{
    public class LoginServiceGraphQL : ILoginService
    {
        private GraphQLHttpClient graphQlClient
            = new("https://localhost:5010/graphql", new NewtonsoftJsonSerializer());
        
        public async Task<UserLogin> ValidateUser(string email, string password)
        {
            var request = new GraphQLRequest
            {
                Query = @"
                mutation
                ValidateUser($credentials : UserLoginInput!)
                {
                    validateUser(credentials : $credentials)
                    {
                        isSuccessful
                        userId
                        isEmployee
                        email
                        password
                    }
                }",
                OperationName = "ValidateUser",
                Variables = new { credentials = new UserLogin()
                {
                    Email = email, Password = password,
                    IsSuccessful = false,
                    UserId = 0,
                    IsEmployee = false
                } }
            };
            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<ValidateUserResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandlingUtility.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.ValidateUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        
    }
}