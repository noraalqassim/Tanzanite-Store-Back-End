using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Entity;
using src.Services.Address;
using static src.DTO.AddressDTO;

namespace src.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController] //Adderss
    public class AddressController : ControllerBase
    {
        /// <summary>
        /// make the list static so all the sellers and the customers access it.
        /// make lis info.
        /// get, post, put and delete method for user without consider is(seller, customer).
        /// </summary>
        protected readonly IAddressService _addressService;

        public AddressController(IAddressService service)
        {
            _addressService = service;
        }

        [HttpPost]
        public async Task<ActionResult<AddressCreateDto>> CreateOne(AddressCreateDto createDto)
        {
            var addressCretaed = await _addressService.CreateOnAsync(createDto);
            return Ok(addressCretaed);
        }

        [HttpGet]
        public async Task<ActionResult<AddressReadDto>> GetAllAsync()
        {
            var addresses = await _addressService.GetAllAsync();
            return Ok(addresses);
        }

        [HttpGet("{addressId}")]
        public async Task<ActionResult<AddressReadDto>> GetByIdAsync(Guid addressId)
        {
            var foundAddress = await _addressService.GetByIdAsync(addressId);
            if (foundAddress == null)
            {
                return NotFound("there is no user in this name");
            }

            return Ok(foundAddress);
        }
    }
}
