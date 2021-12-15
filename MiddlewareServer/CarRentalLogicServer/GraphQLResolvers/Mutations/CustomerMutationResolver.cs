using System;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;
using CarRentalLogicServer.Services;
using CarRentalLogicServer.Services.Interfaces;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Mutations
{
    // class containing mutation resolvers for updating data
    [ExtendObjectType(Name = "Mutation")]
    public class CustomerMutationResolver
    {
        public async Task<Customer> CreateCustomer([Service] ICustomerService customerService, Customer customer)
        {
            try
            {
                return await customerService.CreateCustomerAsync(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Customer> UpdateCustomer([Service] ICustomerService customerService, Customer customer)
        {
            try
            {
                return await customerService.UpdateCustomerAsync(customer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Customer> DeleteCustomer([Service] ICustomerService customerService, long id)
        {
            try
            {
                return await customerService.DeleteCustomerAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}