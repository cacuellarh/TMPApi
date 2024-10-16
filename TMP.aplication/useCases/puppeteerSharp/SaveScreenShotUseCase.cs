
using TMP.domain.commons.response.result;
using TMP.domain.contracts.useCase.puppeteerSharp;
using TPM.domain.contracts.webScraping.takeScreen;
using TMP.domain.dto;

namespace TMP.aplication.useCases.screenShot
{
    public class SaveScreenShotUseCase : ISaveScreenShotUseCase
    {
        private readonly ISaveImageFromUrl _saveScreen;

        public SaveScreenShotUseCase(ISaveImageFromUrl saveScreen)
        {
            _saveScreen = saveScreen;
        }

        public Task<Result<ProductDto>> Execute(string options)
        {
            
            return _saveScreen.CaptureImgFromUrl(options,false);
        }
    }
}
