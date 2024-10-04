using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Services.cart;
using static src.DTO.CartDTO;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartsController : ControllerBase 
    {
        protected readonly ICartService _cartService;

        public CartsController(ICartService service)
        {
            _cartService = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CartReadDTO>> CreateOne([FromBody] CartCreateDTO createDto)
        {
            var authenticateClaims = HttpContext.User;
            var userId = authenticateClaims
                .FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!
                .Value;
            var userGuid = new Guid(userId);

            return await _cartService.CreateOneAsync(userGuid, createDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CartReadDTO>> UpdateOne(Guid id, CartUpdateDTO updateDto)
        {
            var cartUpdated = await _cartService.UpdateOneAsync(id, updateDto);
            if (cartUpdated == null)
            {
                return NotFound();
            }
            return Ok(cartUpdated);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<CartReadDTO>> GetById()
        {
            var authenticateClaims = HttpContext.User;
            var userId = authenticateClaims
                .FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!
                .Value;
            var userGuid = new Guid(userId);
            var cart = await _cartService.GetByIdAsync(userGuid);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }
    }
}
