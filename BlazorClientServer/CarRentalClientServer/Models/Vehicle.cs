using System.Text.Json.Serialization;

namespace CarRentalClientServer.Models
{
    public class Vehicle
    {
        //old legacy class
        
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("model")] public string Model { get; set; }
        
        public Vehicle(int id, string name, string model)
        {
            this.Id = id;
            this.Name = name;
            this.Model = model;
        }

        public Vehicle()
        {
            
        }
        
        /*public int Id { get; set; }
        public int PricePerDay { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public bool IsAutomatic { get; set; }
        public int PowerKw { get; set; }
        public string FuelType { get; set; }
        public int Deposit { get; set; }*/
        
        
        
        
    }
}