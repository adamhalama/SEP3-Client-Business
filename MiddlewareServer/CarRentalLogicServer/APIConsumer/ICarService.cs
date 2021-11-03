using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentalLogicServer.Models;

namespace CarRentalLogicServer.APIConsumer
{
    public interface ICarService
    {
        Task<IList<Car>> GetCarsAsync();
        Task<Car> CreateCarAsync(Car car);
    }
}