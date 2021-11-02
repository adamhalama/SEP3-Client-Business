using System.Text.Json.Serialization;

namespace CarRentalClientServer.Models
{
    public class Car
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("model")] public string Model { get; set; }
    }
}