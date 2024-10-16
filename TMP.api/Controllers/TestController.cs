using Microsoft.AspNetCore.Mvc;
using TMP.domain.contracts.useCase.facades;


namespace TMP.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly IImageTrackFacade facade;

        public TestController(IImageTrackFacade facade)
        {
            this.facade = facade;
        }

        [HttpGet(Name = "get")]
        public async Task<IActionResult> Index()
        {
            var res = await facade.GetAllImageTrack();
            Console.WriteLine(res.Message);
            Console.WriteLine(res.Status);
            Console.WriteLine(res.Data);

            return Ok();
        }
    }
}
