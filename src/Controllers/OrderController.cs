using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Database;
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
        private readonly DatabaseContext _databaseContext;

        public OrderController(DatabaseContext databaseContext, IOrderService orderService)
        {
            _databaseContext = databaseContext;
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<OrderReadDto>> CreateOne([FromBody] OrderCreateDto createDto)
        {
            var authenticateClaims = HttpContext.User;
            var userIdClaim = authenticateClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("User not authenticated.");
            }

            var userGuid = new Guid(userIdClaim);

            // Directly query the database to find the user's address
            var address = await _databaseContext.Addresses
                .FirstOrDefaultAsync(a => a.UserId == userGuid);

            if (address == null)
            {
                return NotFound("Address not found for this user.");
            }

            // Use the found addressId
            var addressId = address.AddressId;

            return await _orderService.CreateOnAsync(userGuid, createDto, addressId);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<OrderReadDto>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllAsync();
            if (orders == null || !orders.Any())
            {
                return NotFound();
            }
            return Ok(orders);
        }


        [HttpGet("{userid}")]
        [Authorize]
        public async Task<ActionResult<OrderReadDto>> GetOrder([FromRoute] Guid userId)
        {
            var order = await _orderService.GetByUserIdAsync(userId);
            if (order == null)
            {
                return NotFound("Order not found for this user.");
            }
            return Ok(order);
        }

        [Authorize(Roles = "Admin")]
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

    }
}
