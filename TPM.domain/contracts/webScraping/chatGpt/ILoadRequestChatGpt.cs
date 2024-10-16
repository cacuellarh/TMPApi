using TMP.domain.commons.response.result;

namespace TPM.domain.contracts.webScraping.chatGpt
{
    public interface ILoadRequestChatGpt
    {
        StringContent LoadJsonConfig(string filePath);
    }
}
