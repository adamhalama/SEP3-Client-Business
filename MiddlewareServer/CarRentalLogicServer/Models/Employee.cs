using System.Text.Json.Serialization;

namespace CarRentalLogicServer.Models
{
    public class Employee
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
        [JsonPropertyName("password")] public string Password { get; set; }
        [JsonPropertyName("clearanceLevel")] public int ClearanceLevel { get; set; }
    }
}