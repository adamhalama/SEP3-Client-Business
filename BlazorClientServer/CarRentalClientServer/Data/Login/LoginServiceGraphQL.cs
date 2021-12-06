using System;
using System.Threading.Tasks;
using CarRentalClientServer.Data.Responses;
using CarRentalClientServer.Models;
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
                LoginUser($userLogin : LoginUserInput!)
                {
                    loginUser(userLogin : $userLogin)
                    {
                        isSuccessful
                        userId
                        isEmployee
                        email
                        password
                    }
                }",
                OperationName = "LoginUser",
                Variables = new { userLogin = new UserLogin()
                    {Email = email, Password = password} }
            };
            try
            {
                var graphQLResponse = await graphQlClient.SendQueryAsync<LoginResponse>(request);
                var errors = graphQLResponse.Errors;
                if (errors != null)
                    ErrorHandling.HandleGraphQLReturnErrors(errors);

                return graphQLResponse.Data.LoginUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        
    }
}