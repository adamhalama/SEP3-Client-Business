using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;
using CarRentalLogicServer.Services;
using CarRentalLogicServer.Services.Interfaces;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Queries
{
    // class containing query resolvers for getting data
    [ExtendObjectType(Name = "Query")]
    public class CustomerResolver
    {
        public IList<Customer> GetAllCustomers([Service] ICustomerService customerService)
        {
            try
            {
                return customerService.GetCustomersAsync().Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Customer> GetCustomer([Service] ICustomerService customerService, long id)
        {
            try
            {
                return await customerService.GetCustomerByIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}