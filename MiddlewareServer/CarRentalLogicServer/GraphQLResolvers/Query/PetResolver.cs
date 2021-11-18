using HotChocolate.Types;

namespace CarRentalLogicServer.QueryResolvers
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