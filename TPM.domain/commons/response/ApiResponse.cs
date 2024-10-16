
using TMP.domain.commons.response.chatGpt;

namespace TMP.domain.commons.response.api
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public ChatGptResponse Response { get; set; }
    }
}
