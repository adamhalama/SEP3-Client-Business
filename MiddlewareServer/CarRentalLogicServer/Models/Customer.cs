using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRentalLogicServer.Models
{
    public class Customer
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("name"), Required(ErrorMessage = "Name cannot be empty!")] public string Name { get; set; }
        [JsonPropertyName("email"), Required] [EmailAddress ( ErrorMessage = "Invalid email address!")] public string Email { get; set; }
        [JsonPropertyName("password")] public string Password { get; set; }
        [JsonPropertyName("address"), Required (ErrorMessage = "Address is required!")] public string Address { get; set; }
        [JsonPropertyName("licenceNumber"), Required (ErrorMessage = "Insert a valid licence number!")] public string LicenceNumber { get; set; }
    }
}