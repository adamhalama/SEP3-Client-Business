using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.APIConsumer.Login;
using CarRentalLogicServer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Mutation
{
    // class containing query resolvers for getting data
    [ExtendObjectType(Name = "Mutation")]
    public class LoginMutationResolver
    {
        public UserLogin ValidateUser([Service] ILoginService loginService, UserLogin credentials)
        {
            return loginService.LoginAsync(credentials).Result;
        } 
    }
}