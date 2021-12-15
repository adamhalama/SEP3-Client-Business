using System.Text.Json.Serialization;
using CarRentalClientServer.Data;
using CarRentalClientServer.Utilities;

namespace CarRentalClientServer.Models
{
    public class Reservation
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("vehicle")] public Vehicle Vehicle { get; set; }
        [JsonPropertyName("customer")] public Customer Customer { get; set; }
        [JsonPropertyName("employee")] public Employee Employee { get; set; }
        [JsonPropertyName("securityDeposit")] public int SecurityDeposit { get; set; }
        [JsonPropertyName("dateCreated")] public long DateCreated { get; set; }
        [JsonPropertyName("dateStart")] public long DateStart { get; set; }
        [JsonPropertyName("dateEnd")] public long DateEnd { get; set; }
        [JsonPropertyName("allowedKm")] public int AllowedKm { get; set; }
        [JsonPropertyName("paymentAmount")] public float PaymentAmount { get; set; }
        [JsonPropertyName("billDate")] public long BillDate { get; set; }
        [JsonPropertyName("isPaid")] public bool IsPaid { get; set; }

        public string GetDateCreatedFormat()
        {
            return TimeConversionUtility.GetDateFormat(DateCreated);
        }
        
        public string GetDateStartFormat()
        {
            return TimeConversionUtility.GetDateTimeFormat(DateStart);
        }
        
        public string GetDateEndFormat()
        {
            return TimeConversionUtility.GetDateTimeFormat(DateEnd);
        }
        
        public string GetBillDateFormat()
        {
            return TimeConversionUtility.GetDateFormat(BillDate);
        }
        
    }
}