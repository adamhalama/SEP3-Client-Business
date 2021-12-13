using System.Text.Json.Serialization;

namespace CarRentalLogicServer.Models
{
    public class UserLogin
    {
        [JsonPropertyName("successful")]
        public bool IsSuccessful { get; set; }
        [JsonPropertyName("userId")]
        public long UserId { get; set; }
        [JsonPropertyName("employee")]
        public bool IsEmployee { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}