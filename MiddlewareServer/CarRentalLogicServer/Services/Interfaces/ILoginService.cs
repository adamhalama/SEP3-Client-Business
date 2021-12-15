using System.Threading.Tasks;
using CarRentalLogicServer.Models;

namespace CarRentalLogicServer.Services.Interfaces
{
    public interface ILoginService
    {
        Task<UserLogin> LoginAsync(UserLogin credentials);
    }
}