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
    public class EmployeeMutationResolver
    {
        public async Task<Employee> CreateEmployee([Service] IEmployeeService employeeService, Employee employee)
        {
            try
            {
                return await employeeService.CreateEmployeeAsync(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Employee> UpdateEmployee([Service] IEmployeeService employeeService, Employee employee)
        {
            try
            {
                return await employeeService.UpdateEmployeeAsync(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Employee> DeleteEmployee([Service] IEmployeeService employeeService, long id)
        {
            try
            {
                return await employeeService.DeleteEmployeeAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
