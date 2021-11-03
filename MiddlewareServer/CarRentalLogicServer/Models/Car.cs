using System.Text.Json.Serialization;

namespace CarRentalLogicServer.Models
{
    public class Car
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("model")] public string Model { get; set; }
        
        public Car(int id, string name, string model)
        {
            this.Id = id;
            this.Name = name;
            this.Model = model;
        }

        public Car()
        {
            
        }
    }
}