using System.Threading.Tasks;
using CarRentalLogicServer.Models;

namespace CarRentalLogicServer.APIConsumer.Login
{
    public interface ILoginService
    {
        Task<UserLogin> LoginAsync(UserLogin credentials);
    }
}