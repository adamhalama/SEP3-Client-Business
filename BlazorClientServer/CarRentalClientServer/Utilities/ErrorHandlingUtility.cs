using System;
using System.Runtime.InteropServices;
using GraphQL;

namespace CarRentalClientServer.Utilities
{
    public static class ErrorHandlingUtility
    {
        public static void HandleGraphQLReturnErrors(GraphQLError[] errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error.Message);
            }

            var extensions = errors[0].Extensions;
            if (extensions != null && extensions["message"] != null && !extensions["message"].Equals(""))
                throw new ExternalException(extensions["message"].ToString());

            throw new Exception(errors[0].Message);
        }
    }
}