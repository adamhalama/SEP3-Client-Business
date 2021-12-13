using System.Threading.Tasks;
using CarRentalClientServer.Models;

namespace CarRentalClientServer.Data
{
    public interface ILoginService
    {
        Task<UserLogin> ValidateUser(string email, string password);
    }
}