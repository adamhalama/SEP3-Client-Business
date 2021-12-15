using System.Threading.Tasks;
using CarRentalClientServer.Data;

namespace CarRentalClientServer.Utilities
{
    public class CheckAvailabilityUtility
    {
        public static async Task<bool> CheckForAvailability(long dateStart, long dateEnd, long vehicleId, IVehicleService vehicleService)
        {
            bool isValid = false;
            var availableVehicles = await vehicleService.GetAvailableVehiclesAsync(dateStart, dateEnd);
            foreach (var veh in availableVehicles)
            {
                if (veh.Id == vehicleId)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }
    }
}