using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
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
        [HttpPost, Authorize]
        public async Task<IActionResult> AddOrderQualityAsync(OrderQuality order)
        {
            await orderQualityService.AddOrderQualityAsync(order);
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOrderQualityAsync(OrderQuality orderQuality)
        {
            await orderQualityService.UpdateOrderQualityAsync(orderQuality);
            return Ok(orderQuality);
        }

        [HttpGet("passport/{id}")]
        public async Task<IActionResult> GetPassportQualityAsync(int id)
        {
            var result =  await orderQualityService.GetPassportQualityAsync(id);
            if (result.Length == 0)
            {
                return BadRequest();
            }
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = id.ToString() + ".xlsx";
            return File(result, contentType, fileName);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderQualityByIdAsync(int id)
        {
            var result = await orderQualityService.GetOrderQualityByIdAsync(id);
            if (result ==  null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
