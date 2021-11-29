using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Query
{
    // class containing query resolvers for getting data
    [ExtendObjectType(Name = "Query")]
    public class CustomerResolver
    {
        public IList<Customer> GetAllCustomers([Service] ICustomerService customerService)
        {
            return customerService.GetCustomersAsync().Result;
        }

        public async Task<Customer> GetCustomer([Service] ICustomerService customerService, int id)
        {
            return await customerService.GetCustomerByIdAsync(id);
        }
    }
}