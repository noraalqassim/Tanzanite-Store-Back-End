using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Entity;
using src.Repository;
using src.Services.OrderGemstone;
using static src.DTO.OrderGemstoneDTO;

namespace src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderGemstoneController : ControllerBase
    {
        private readonly IOrderGemstoneService _orderGemstoneService;

        public OrderGemstoneController(IOrderGemstoneService service)
        {
            _orderGemstoneService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderGemstone>>> GetAllOrderGemstones()
        {
            var orderGemstonesList = await _orderGemstoneService.GetAllAsync();
            return Ok(orderGemstonesList); //200 OK
        }

        [HttpGet("{OrderProductId}")]
        public async Task<ActionResult<OrderGemstoneReadDto>> GetById(Guid OrderProductId)
        {
            var foundOrderProduct = await _orderGemstoneService.GetByIdAsync(OrderProductId);
            if (foundOrderProduct == null)
            {
                return NotFound("Order Product not found"); //400 Not Found
            }
            return Ok(foundOrderProduct); //200 Ok
        }

        //Create 
        [HttpPost]
        [Authorize(Roles = "Admin")] //--> Just the Admin Can Create New Jewelry
        public async Task<ActionResult<JewelryReadDto>> CreateOne(OrderGemstoneCreateDto createDto)
        {
            var nweOrderProduct = await _orderGemstoneService.CreateOnAsync(createDto);
            return Ok(nweOrderProduct);//200 Ok
        }

        //Update
        [HttpPut("{OrderProductId}")]
        public async Task<ActionResult<OrderGemstoneReadDto>> UpdateOne(Guid OrderProductId, OrderGemstoneUpdateDto updateDto)
        {
            var OrderProductUpdate = await _orderGemstoneService.UpdateOnAsync(OrderProductId, updateDto);
            if (OrderProductUpdate == null)
            {
                return NotFound("Order Product item not found"); //400  Not Found
            }
            return Ok(OrderProductUpdate); //200 OK
        }
        //Delete

        [HttpDelete("{OrderProductId}")]
        public async Task<ActionResult> DeleteOne(Guid OrderProductId)
        {
            var OrderProductDeleted = await _orderGemstoneService.DeleteOnAsync(OrderProductId);
            if (OrderProductDeleted == false)
            {
                return NotFound(); // 404 Not Found
            }
            return NoContent(); // 200 OK 
        }
    }
}
