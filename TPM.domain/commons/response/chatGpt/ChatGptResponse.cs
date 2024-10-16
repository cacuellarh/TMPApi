
using System.Text.Json.Serialization;

namespace TMP.domain.commons.response.chatGpt
{
    public class ChatGptResponse
    {
        public string id { get; set; }

        [JsonPropertyName("object")]
        public string Object { get; set; }
        public long created { get; set; }
        public string model { get; set; }
        public List<Choice> choices { get; set; }
        public Usage usage { get; set; }
        public string systemFingerprint { get; set; }
    }
}
