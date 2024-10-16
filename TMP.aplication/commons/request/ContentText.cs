

using System.Text.Json.Serialization;

namespace TMP.aplication.commons.request
{
    public class ContentText
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("text")]
        public string? Text { get; set; }

        //[JsonPropertyName("image_url")]
        //public ImageUrl? ImageUrl { get; set; }
    }
}
