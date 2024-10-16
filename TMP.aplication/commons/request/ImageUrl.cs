
using System.Text.Json.Serialization;


public class ImageUrl
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
}