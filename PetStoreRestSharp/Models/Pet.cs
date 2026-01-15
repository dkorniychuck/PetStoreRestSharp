using System.Text.Json.Serialization;

namespace PetStoreRestSharp.Models
{
    public class Pet
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        [JsonPropertyName("photoUrls")]
        public List<string>? PhotoUrls { get; set; }
    }
}