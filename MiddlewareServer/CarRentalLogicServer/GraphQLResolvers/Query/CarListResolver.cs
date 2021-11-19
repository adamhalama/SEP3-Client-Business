using System.Collections.Generic;
using System.Linq;
using CarRentalLogicServer.APIConsumer;
using CarRentalLogicServer.Models.REST;
using HotChocolate;
using HotChocolate.Types;

namespace CarRentalLogicServer.GraphQLResolvers.Query
{
    [ExtendObjectType(Name="Query")]
    public class CarListResolver
    {
        public List<Car> GetAllCars([Service] ICarService carService)
        {
            return carService.GetCarsAsync().Result.ToList();
        }
    }
}