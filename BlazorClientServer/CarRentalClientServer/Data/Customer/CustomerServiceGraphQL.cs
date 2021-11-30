using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data
{
    public class CustomerServiceGraphQL : ICustomerService
    {
        public Task<IList<Customer>> GetCustomersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> GetCustomerAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> CreateCustomerAsync(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteCustomerAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}