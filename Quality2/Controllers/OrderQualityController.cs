using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quality2.Entities;
using Quality2.IRepository;
using Quality2.Services;

namespace Quality2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderQualityController : ControllerBase
    {

        private readonly IOrderQuailtyService orderQualityService;
        public OrderQualityController(IOrderQuailtyService orderQualityService)
        {
            this.orderQualityService = orderQualityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersQualityAsync()
        {
            var orders = await orderQualityService.GetOrdersQualityAsync();
            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrderQualityAsync(OrderQuality order)
        {
            await orderQualityService.AddOrderQualityAsync(order);
            return Ok();
        }
    }
}
