

using System.Text.Json.Serialization;

namespace TMP.aplication.commons.request
{
    public class ContentImage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("image_url")]
        public ImageUrl ImageUrl { get; set; }

        //[JsonPropertyName("detail")]
        //public string Detail { get; set; }
    }
}
