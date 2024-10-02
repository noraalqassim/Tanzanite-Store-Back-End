using Microsoft.AspNetCore.Mvc;
using src.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.Services.Order;
using static src.DTO.OrderDTO;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderReadDto>> CreateOne(OrderCreateDto createDto)
        {
            var nweOrderProduct = await _orderService.CreateOnAsync(createDto);
            return Ok(nweOrderProduct);//200 Ok
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderReadDto>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{OrderId}")]
        public async Task<ActionResult<OrderReadDto>> GetOrder(Guid OrderId)
        {
            var order = await _orderService.GetByIdAsync(OrderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPut("{OrderId}")]
        public async Task<IActionResult> UpdateOrder(Guid OrderId, OrderUpdateDto orderUpdateDto)
        {
            var updated = await _orderService.UpdateOnAsync(OrderId, orderUpdateDto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{OrderId}")]
        public async Task<IActionResult> DeleteOrder(Guid OrderId)
        {
            var deleted = await _orderService.DeleteOneAsync(OrderId);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}