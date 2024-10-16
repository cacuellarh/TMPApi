using Microsoft.AspNetCore.Mvc;
using TMP.domain.contracts.useCase.product;
using TMP.domain.dto;


namespace TMP.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IUseCaseCreateProduct _useCaseCreateProduct;

        public ProductController(IUseCaseCreateProduct useCaseCreateProduct)
        {
            _useCaseCreateProduct = useCaseCreateProduct;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto product)
        {
            var result = await _useCaseCreateProduct.Execute(product);

            return Ok(result);
        }
    }
}
