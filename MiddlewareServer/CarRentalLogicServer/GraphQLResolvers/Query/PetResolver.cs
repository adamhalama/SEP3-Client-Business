using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Query
{
    [ExtendObjectType(Name = "Query")]
    public class PetResolver
    {
        public string YourPet()
        {
            return "Dog";
        }

        public string FetchPet()
        {
            return "got a pet";
        }
    }
}