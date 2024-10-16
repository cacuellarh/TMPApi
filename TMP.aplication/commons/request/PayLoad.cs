using System.Text.Json.Serialization;

namespace TMP.aplication.commons.request
{
    public class PayLoad
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; }

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; }

        [JsonPropertyName("response_format")]
        public Dictionary<string, string> ResponseFormat;
    }
}
