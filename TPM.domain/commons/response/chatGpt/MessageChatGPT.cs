
using System.Text.Json;

namespace TMP.domain.commons.response.chatGpt
{
    public class MessageChatGPT
    {
        public string role { get; set; }
        public string content { get; set; }
        public object refusal { get; set; }
    }
}
