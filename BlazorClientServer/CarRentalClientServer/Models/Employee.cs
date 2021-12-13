using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarRentalClientServer.Models
{
    public class Employee
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("name"), Required(ErrorMessage = "Name cannot be empty!")] public string Name { get; set; }
        [JsonPropertyName("email"), Required] [EmailAddress(ErrorMessage = "Invalid email address!")] public string Email { get; set; }
        [JsonPropertyName("password")] public string Password { get; set; }
        [JsonPropertyName("clearanceLevel")] public int ClearanceLevel { get; set; }
    }
}