using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data
{
    public class EmployeeServiceGraphQL : IEmployeeService
    {
        public Task<IList<Employee>> GetEmployeesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> GetEmployeeAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteEmployeeAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}