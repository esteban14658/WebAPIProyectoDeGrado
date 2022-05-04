using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PG.Presentation.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("{idShop:int}")]
        public async Task<ActionResult<List<OrderDto>>> Post([FromBody] List<OrderDto> orderList, int idShop)
        {
            var orders = await _orderService.AddOrderToShop(idShop, orderList);
            return Created("", orders);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<OrderDto>> Put([FromBody] OrderDto order, int id)
        {
            var orders = await _orderService.Update(order, id);
            return Ok(orders);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _orderService.Delete(id);
            return NoContent();
        }
    }
}
