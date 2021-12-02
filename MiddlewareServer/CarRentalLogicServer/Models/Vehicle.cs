using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CarRentalLogicServer.Models
{
    public class Vehicle
    {
        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("type")] public string Type { get; set; }
        [JsonPropertyName("pricePerDay")] public int PricePerDay { get; set; }
        [JsonPropertyName("seatsCount")] public int SeatsCount { get; set; }
        [JsonPropertyName("isAutomatic")] public bool IsAutomatic { get; set; }
        [JsonPropertyName("powerKw")] public int PowerKw { get; set; }
        [JsonPropertyName("fuelType")] public string FuelType { get; set; }
        [JsonPropertyName("deposit")] public int Deposit { get; set; }
    }
}