using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;

namespace CarRentalLogicServer.APIConsumer
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}