
namespace TMP.domain.commons.response.chatGpt
{
    public class Usage
    {
        public int promptTokens { get; set; }
        public int completionTokens { get; set; }
        public int totalTokens { get; set; }
    }
}
