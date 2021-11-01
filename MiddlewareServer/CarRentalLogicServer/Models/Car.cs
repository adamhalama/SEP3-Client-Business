using System.Text.Json.Serialization;

namespace CarRentalLogicServer.Models
{
    public class Car : CarList
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("model")]
        public string Model { get; set; }
    }
}