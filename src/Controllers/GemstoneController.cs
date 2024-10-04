using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Entity;
using src.Services.Gemstone;
using src.Utils;
using static src.DTO.GemstonesDTO;

namespace src.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")] //api/v1/Gemstone
    public class GemstoneController : ControllerBase
    {
        /// <summary>
        /// The GemstoneController file serves as the entry point for handling HTTP requests related to gemstones in the application.
        /// It provides endpoints for creating, reading, updating, and deleting gemstone records.
        /// 1- Getting a list of all gemstones.
        /// 2- Retrieving a specific gemstone by its ID.
        /// 3- Creating a new gemstone entry.
        /// 4- Updating gemstone information.
        /// 5- Deleting a gemstone record.
        /// </summary>
        protected readonly IGemstoneService _gemstoneService;

        public GemstoneController(IGemstoneService gemstoneService)
        {
            _gemstoneService = gemstoneService;
        }

        // GET: api/v1/Gemstone
        // Get all gemstones
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<GemstoneReadDto>>> GetAll()
        {
            var gemstonesList = await _gemstoneService.GetAllAsync();
            return Ok(gemstonesList);
        }


        // Get a gemstone by its ID
        [AllowAnonymous]
        [HttpGet("{GemstoneId}")] // GET: api/v1/Gemstone/{GemstoneId}
        public async Task<ActionResult<GemstoneReadDto>> GetById(Guid GemstoneId)
        {
            var foundGemstone = await _gemstoneService.GetByIdAsync(GemstoneId);
            if (foundGemstone == null)
            {
                return NotFound("Gemstone not found");
            }
            return Ok(foundGemstone);
        }

        // Create a new gemstone
        [Authorize(Roles = "Admin")]
        [HttpPost] //api/v1/Gemstone
        public async Task<ActionResult<GemstoneReadDto>> CreateOne(GemstoneCreateDto createDto)
        {
            var newGemstone = await _gemstoneService.CreateOneAsync(createDto);
            return Ok(newGemstone);
        }


        // Update a gemstone
        [Authorize(Roles = "Admin")]
        [HttpPut("{GemstoneId}")] // PUT: api/v1/Gemstone/{GemstoneId}
        public async Task<ActionResult> UpdateOne(Guid GemstoneId, GemstoneUpdateDto updateDto)
        {
            var gemstoneUpdated = await _gemstoneService.UpdateOneAsync(GemstoneId, updateDto);
            if (gemstoneUpdated == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(gemstoneUpdated); // 200 OK 
        }

        // Delete a gemstone by its ID
        [Authorize(Roles = "Admin")]
        [HttpDelete("{GemstoneId}")] // DELETE: api/v1/Gemstone/{GemstoneId}
        public async Task<ActionResult> DeleteOne(Guid GemstoneId)
        {
            var gemstoneDeleted = await _gemstoneService.DeleteOneAsync(GemstoneId);
            if (gemstoneDeleted == false)
            {
                return NotFound();
            }
            return NoContent(); // 200 OK 
        }

        //Searsh with pagination
        [AllowAnonymous]
        [HttpGet("Search")] // /api/v1/Gemstone/Search?Limit=3&Offset=0&Search=ring
        public async Task<ActionResult<List<GemstoneReadDto>>> GetAllJewelryBySearch([FromQuery] PaginationOptions paginationOptions)
        {
            var gemstonesList = await _gemstoneService.GetAllBySearchAsync(paginationOptions);
            return Ok(gemstonesList);
        }

        [AllowAnonymous]
        [HttpGet("Filter")] // /api/v1/Gemstone/Filter?Name or MinPrice Or MaxPrice
        public async Task<ActionResult<List<Gemstones>>> FilterJe([FromQuery] FilterationOptions jewelryFilter)
        {
            var gemstonesList = await _gemstoneService.GetAllByFilterationAsync(jewelryFilter);
            return Ok(gemstonesList);
        }

    }
}