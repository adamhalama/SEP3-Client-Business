using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data
{
    public interface IEmployeeService
    {
        Task<IList<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeAsync(long id);
        Task<Employee> CreateEmployeeAsync(string name, string email, string password, int clearanceLevel);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task<bool> DeleteEmployeeAsync(long id);
    }
}