using System.Threading.Tasks;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Mutation
{
    // class containing mutation resolvers for updating data
    [ExtendObjectType(Name = "Mutation")]
    public class EmployeeMutationResolver
    {
        public async Task<Employee> CreateEmployee([Service] IEmployeeService employeeService, Employee employee)
        {
            return await employeeService.CreateEmployeeAsync(employee);
        }

        public async Task<Employee> UpdateEmployee([Service] IEmployeeService employeeService, Employee employee)
        {
            return await employeeService.UpdateEmployeeAsync(employee);
        }

        public async Task<Employee> DeleteEmployee([Service] IEmployeeService employeeService, long id)
        {
            return await employeeService.DeleteEmployeeAsync(id);
        }
    }
}
