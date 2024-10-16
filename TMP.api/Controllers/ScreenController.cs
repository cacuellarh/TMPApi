using Microsoft.AspNetCore.Mvc;
using TMP.api.request;
using TMP.domain.contracts.useCase.puppeteerSharp;

namespace TMP.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreenController : Controller
    {
        private readonly ISaveScreenShotUseCase _useCaseScreenShot;

        public ScreenController(ISaveScreenShotUseCase useCaseScreenShot)
        {
            _useCaseScreenShot = useCaseScreenShot;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UrlScanImageRequest url)
        {
            var response = await _useCaseScreenShot.Execute(url.url);

            return Ok(response);   
        }
    }
}
