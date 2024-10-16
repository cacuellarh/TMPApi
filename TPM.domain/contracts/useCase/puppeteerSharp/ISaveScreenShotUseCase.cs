using TMP.domain.commons.response.result;
using TMP.domain.dto;

namespace TMP.domain.contracts.useCase.puppeteerSharp
{
    public interface ISaveScreenShotUseCase : IUseCase<string,Result<ProductDto>>
    {
    }
}
