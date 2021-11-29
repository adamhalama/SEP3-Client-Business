using System.Text.Json.Serialization;

namespace CarRentalLogicServer.Models
{
    public class Reservation
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("vehicleId")] public long VehicleId { get; set; }
        [JsonPropertyName("customerId")] public long CustomerId { get; set; }
        [JsonPropertyName("employeeId")] public long EmployeeId { get; set; }
        [JsonPropertyName("securityDeposit")] public int SecurityDeposit { get; set; }
        [JsonPropertyName("dateCreated")] public long DateCreated { get; set; }
        [JsonPropertyName("dateStart")] public long DateStart { get; set; }
        [JsonPropertyName("dateEnd")] public long DateEnd { get; set; }
        [JsonPropertyName("allowedKm")] public int AllowedKm { get; set; }
        [JsonPropertyName("paymentAmount")] public int PaymentAmount { get; set; }
        [JsonPropertyName("billDate")] public long BillDate { get; set; }
        [JsonPropertyName("isPaid")] public bool IsPaid { get; set; }
    }
}