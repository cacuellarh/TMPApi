
namespace TMP.domain.commons.response.chatGpt
{
    public class Choice
    {
        public int index { get; set; }
        public MessageChatGPT message { get; set; }
        public object logprobs { get; set; }
        public string finishReason { get; set; }
    }
}
