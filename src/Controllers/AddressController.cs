using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Entity;
using src.Services.Address;
using static src.DTO.AddressDTO;

namespace src.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController] 
    public class AddressController : ControllerBase
    {
 
        protected readonly IAddressService _addressService;

        public AddressController(IAddressService service)
        {
            _addressService = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<AddressReadDto>> CreateOne(
            [FromBody] AddressCreateDto createDto
        )
        {
            var authenticateClaims = HttpContext.User;
            var userId = authenticateClaims
                .FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!
                .Value;
            var userGuid = new Guid(userId);

            return await _addressService.CreateOnAsync(userGuid, createDto);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AddressReadDto>> GetAllAsync()
        {
            var addresses = await _addressService.GetAllAsync();
            return Ok(addresses);
        }

        [HttpGet("UserAddress")]
        [Authorize]
        public async Task<ActionResult<List<AddressReadDto>>> GetAddressesByUserId()
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var foundAddresses = await _addressService.GetByIdAsync(userId);

            if (foundAddresses == null || foundAddresses.Count == 0)
            {
                return NotFound("No addresses found for this user.");
            }

            return Ok(foundAddresses);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAddressAsync(Guid id)
        {
            var isDeleted = await _addressService.DeleteOnAsync(id);

            if (!isDeleted)
            {
                return NotFound("Address not found.");
            }

            return Ok("Address is Delete"); 
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<AddressReadDto>> UpdateAddressesAsync(
            AddressUpdateDto updateDto
        )
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var updatedAddressDto = await _addressService.UpdateOnAsync(userId, updateDto);

            if (updatedAddressDto == null)
            {
                return NotFound("Address not found.");
            }

            return Ok(updatedAddressDto);
        }
    }
}
