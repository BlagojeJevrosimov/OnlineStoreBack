using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderBLL.Contracts.Services;
using OrderBLL.DTOs.Request;
using OrderDAL.Entites;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _productService;

        private int _userId
        {
            get => Convert.ToInt32(HttpContext?.Items["Id"]);
        }
        public OrderController(IOrderService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [UserAuthorization]
        public async Task<ActionResult<IEnumerable<Order>>> GetProducts()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpGet("{id}")]
        [UserAuthorization]
        public async Task<ActionResult<Order>> GetProduct(int id)
        {
            Order product = await _productService.GetByIdAsync(id);

            return product;
        }

        [HttpPut]
        [UserAuthorization(Common.Enums.Role.Salesman)]
        public async Task<IActionResult> PutProduct(Order request)
        {
            await _productService.UpdateAsync(request);

            return Ok();
        }

        [HttpPost]
       // [UserAuthorization]
        //izmenjaj pa istestiraj
        public async Task<ActionResult<Order>> AddOrder(AddOrderRequest request)
        {
            var response = await _productService.AddOrderAsync(request, _userId);

            return Ok(response);
        }


        [HttpDelete("{id}")]
        [UserAuthorization(Common.Enums.Role.Salesman)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}

