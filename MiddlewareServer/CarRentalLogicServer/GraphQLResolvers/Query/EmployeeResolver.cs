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
            return employeeService.GetEmployeesAsync().Result;
        }

        public async Task<Employee> GetEmployee([Service] IEmployeeService employeeService, int id)
        {
            return await employeeService.GetEmployeeByIdAsync(id);
        }
    }
}