using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace CarRentalClientServer.Models
{
    public class Vehicle
    {
        public Vehicle(long id, string name, string type, int pricePerDay, int seatsCount, bool isAutomatic, int powerKw, string fuelType, int deposit)
        {
            Id = id;
            Name = name;
            Type = type;
            PricePerDay = pricePerDay;
            SeatsCount = seatsCount;
            IsAutomatic = isAutomatic;
            PowerKw = powerKw;
            FuelType = fuelType;
            Deposit = deposit;
        }

        [JsonPropertyName("id")] public long Id { get; set; }
        [JsonPropertyName("name")] [NotNull] public string Name { get; set; }
        [NotNull] [JsonPropertyName("type")] public string Type { get; set; }
        [JsonPropertyName("pricePerDay")] public int PricePerDay { get; set; }
        [NotNull] [JsonPropertyName("seatsCount")] public int SeatsCount { get; set; }
        [JsonPropertyName("isAutomatic")] public bool IsAutomatic { get; set; }
        [JsonPropertyName("powerKw")] public int PowerKw { get; set; }
        [NotNull] [JsonPropertyName("fuelType")] public string FuelType { get; set; } 
        [JsonPropertyName("deposit")] public int Deposit { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Type)}: {Type}, {nameof(PricePerDay)}: {PricePerDay}, {nameof(SeatsCount)}: {SeatsCount}, {nameof(IsAutomatic)}: {IsAutomatic}, {nameof(PowerKw)}: {PowerKw}, {nameof(FuelType)}: {FuelType}, {nameof(Deposit)}: {Deposit}";
        }

        //old legacy class

        /*[JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("model")] public string Model { get; set; }*/

        /*// public Vehicle(int id, string name, string model)
        // {
        //     this.Id = id;
        //     this.Name = name;
        //     this.Model = model;
        // }*/

        public Vehicle()
        {
        }
    }
}