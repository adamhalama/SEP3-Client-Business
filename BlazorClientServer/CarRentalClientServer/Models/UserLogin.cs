using System.Text.Json.Serialization;

namespace CarRentalClientServer.Models
{
    public class UserLogin
    {
        [JsonPropertyName("isSuccessful")]
        public bool IsSuccessful { get; set; }
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        [JsonPropertyName("isEmployee")]
        public bool IsEmployee { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}