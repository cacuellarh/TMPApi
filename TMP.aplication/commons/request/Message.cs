
using System.Text.Json.Serialization;

namespace TMP.aplication.commons.request
{
    public class Message
    {
        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("content")]
        public List<object> Content { get; set; }
    }
}
