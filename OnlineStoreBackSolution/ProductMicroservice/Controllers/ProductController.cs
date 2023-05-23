using Common;
using Microsoft.AspNetCore.Mvc;
using ProductBLL.Contracts.Services;
using ProductBLL.Services;
using ProductDAL.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [UserAuthorization]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            Product product = await _productService.GetByIdAsync(id);

            return product;
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct(Product request)
        {
            await _productService.UpdateAsync(request);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> RegisterProduct(Product request)
        {
            var response = await _productService.AddAsync(request);

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
