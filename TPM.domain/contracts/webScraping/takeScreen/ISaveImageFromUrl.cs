using TMP.domain.commons.response.result;
using TMP.domain.dto;

namespace TPM.domain.contracts.webScraping.takeScreen
{
    public interface ISaveImageFromUrl
    {
        public Task<Result<ProductDto>> CaptureImgFromUrl(string url, bool resizeImage);
    }
}
