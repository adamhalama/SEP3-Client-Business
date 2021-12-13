using System.Threading.Tasks;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Mutation
{
    // class containing mutation resolvers for updating data
    [ExtendObjectType(Name = "Mutation")]
    public class CustomerMutationResolver
    {
        public async Task<Customer> CreateCustomer([Service] ICustomerService customerService, Customer customer)
        {
            return await customerService.CreateCustomerAsync(customer);
        }

        public async Task<Customer> UpdateCustomer([Service] ICustomerService customerService, Customer customer)
        {
            return await customerService.UpdateCustomerAsync(customer);
        }

        public async Task<Customer> DeleteCustomer([Service] ICustomerService customerService, long id)
        {
            return await customerService.DeleteCustomerAsync(id);
        }
    }
}