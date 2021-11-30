using System.Text.Json.Serialization;

namespace CarRentalClientServer.Models
{
    public class Customer
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
        [JsonPropertyName("password")] public string Password { get; set; }
        [JsonPropertyName("address")] public string Address { get; set; }
        [JsonPropertyName("licenceNumber")] public string LicenceNumber { get; set; }
    }
}