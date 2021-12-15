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
    public class EmployeeResolver
    {
        public IList<Employee> GetAllEmployees([Service] IEmployeeService employeeService)
        {
            try
            {
                return employeeService.GetEmployeesAsync().Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Employee> GetEmployee([Service] IEmployeeService employeeService, long id)
        {
            try
            {
                return await employeeService.GetEmployeeByIdAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}