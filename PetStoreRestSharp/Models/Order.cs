using System.Text.Json.Serialization;
namespace PetStoreRestSharp.Models
{
    public class Order
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("petId")]
        public long PetId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("complete")]
        public bool Complete { get; set; }
    }
}
