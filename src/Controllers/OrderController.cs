using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.DTO;
using src.Services.Order;
using static src.DTO.OrderDTO;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<OrderReadDto>> CreateOne([FromBody] OrderCreateDto createDto)
        {
            // exact user information by token
            var authenticateClaims = HttpContext.User;
            // get user id by claims
            var UserId = authenticateClaims
                .FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!
                .Value;
            // string => Guid
            var userGuid = new Guid(UserId);
            return await _orderService.CreateOnAsync(userGuid, createDto);
        }

        // ---------- Get all Orders ----------
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult<List<OrderReadDto>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound(); // Or you could return an empty list, depending on your preference
            }

            return Ok(orders);
        }

        // [HttpGet]
        // public async Task<ActionResult<List<OrderReadDto>>> GetAllOrders()
        // {
        //     var orders = await _orderService.GetAllAsync();
        //     return Ok(orders);
        // }

        // [HttpGet("{OrderId}")]
        // public async Task<ActionResult<OrderReadDto>> GetOrder(Guid OrderId)
        // {
        //     var order = await _orderService.GetByIdAsync(OrderId);
        //     if (order == null)
        //     {
        //         return NotFound();
        //     }
        //     return Ok(order);
        // }

        // [HttpPut("{OrderId}")]
        // public async Task<IActionResult> UpdateOrder(Guid OrderId, OrderUpdateDto orderUpdateDto)
        // {
        //     var updated = await _orderService.UpdateOnAsync(OrderId, orderUpdateDto);
        //     if (!updated)
        //     {
        //         return NotFound();
        //     }
        //     return NoContent();
        // }

        // [HttpDelete("{OrderId}")]
        // public async Task<IActionResult> DeleteOrder(Guid OrderId)
        // {
        //     var deleted = await _orderService.DeleteOneAsync(OrderId);
        //     if (!deleted)
        //     {
        //         return NotFound();
        //     }
        //     return NoContent();
        // }
    }
}
