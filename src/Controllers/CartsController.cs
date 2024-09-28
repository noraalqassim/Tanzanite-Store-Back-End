using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Services.cart;
using Microsoft.AspNetCore.Mvc;
using static src.DTO.CartDTO;

// Controller:
// Role: Acts as the entry point for handling HTTP requests. 
// It defines endpoints (routes) for clients to interact with the application.

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    // api/v1/carts
    public class CartsController : ControllerBase // CartsController inherits from ControllerBase
    {

        // field
        protected readonly ICartService _cartService;

        // Constructor for DI (Dependency Injection)
        public CartsController(ICartService service)
        {
            _cartService = service;
        }

        // Create a new Cart
        [HttpPost]
        public async Task<ActionResult<CartReadDTO>> CreateOne(CartCreateDTO createDto)
        {
            var cartCreated = await _cartService.CreateOneAsync(createDto);
            return Ok(cartCreated); // 200 Ok
        }

        // Get all carts
        [HttpGet]
        public async Task<ActionResult<List<CartReadDTO>>> GetAll()
        {
            var cartList = await _cartService.GetAllAsync();
            return Ok(cartList); // 200 Ok
        }

        // Get cart by id
        [HttpGet("{id}")]
        public async Task<ActionResult<CartReadDTO>> GetById(Guid id)
        {
            var cart = await _cartService.GetByIdAsync(id);
            if (cart == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(cart); // 200 OK 
        }

        // Update a cart
        [HttpPut("{id}")]
        public async Task<ActionResult<CartReadDTO>> UpdateOne(Guid id, CartUpdateDTO updateDto)
        {
            var cartUpdated = await _cartService.UpdateOneAsync(id, updateDto);
            if (cartUpdated == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(cartUpdated); // 200 OK 
        }

        // Delete a cart
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOne(Guid id)
        {
            var cartDeleted = await _cartService.DeleteOneAsync(id);
            if (cartDeleted == false)
            {
                return NotFound(); // 404 Not Found
            }
            return NoContent(); // 200 OK 
        }

    } // end class
} // end namespace