using Microsoft.AspNetCore.Mvc;
using TMP.aplication.contracts.repository;
using TMP.domain.contracts.useCase.facades;
using TMP.domain.request.imageTrackRequest;
using TPM.domain.entities;


namespace TMP.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageTrackController : Controller
    {
        private readonly IImageTrackFacade _facade;
        private readonly IImageTrackRepository repos;

        public ImageTrackController(IImageTrackFacade facade, IImageTrackRepository image)
        {
            _facade = facade;
            repos = image;
        }

        [HttpGet(Name = "getAllImageTrack")]
        public async Task<IActionResult> Index()
        {
            var response = await _facade.GetAllImageTrack();

            if (response.Status)
            {
                return Ok(response);
            }

            return BadRequest();
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateImageTrackRequest request)
        {

            var res2 = await _facade.CreateImageTrack(request);

            if (res2.IsSuccess)
            {
                return Ok(res2);
            }
            return BadRequest(res2);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _facade.GetImageTrack((image) => image.Id == id);

            if (response.Status)
            {
                return Ok(response);
            }

            return BadRequest(response);

        }

        [HttpPut]
        public async Task<IActionResult> Update(ImageTrack image)
        {

            var response = await _facade.UpdateImageTrack(image);
            return BadRequest(response);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ImageTrack image)
        {

            var response = await _facade.DeleteImageTrack(image);
            return BadRequest(response);

        }
    }
}
