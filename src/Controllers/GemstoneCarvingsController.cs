using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Entity;
using src.Services.GemstoneCravings;
using static src.DTO.GemstoneCarvingsDTO;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")] //api/v1/GemstoneCarving
    public class GemstoneCarvingsController : ControllerBase
    {
        protected readonly IGemstoneCarvingService _gemstoneCarvingService;
        public GemstoneCarvingsController(IGemstoneCarvingService gemstoneCarvingService)
        {
            _gemstoneCarvingService = gemstoneCarvingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GemstoneCarvingReadDto>>> GetAll()
        {
            var carvingsList = await _gemstoneCarvingService.GetAllAsync();
            return Ok(carvingsList);
        }

        [HttpGet("{carvingId}")]
        public async Task<ActionResult<GemstoneCarvingReadDto>> GetById(Guid carvingId)
        {
            var foundCarving = await _gemstoneCarvingService.GetByIdAsync(carvingId);
            if (foundCarving == null)
            {
                return NotFound("Gemstone carving not found");
            }
            return Ok(foundCarving);
        }

        [HttpPost]
        public async Task<ActionResult<GemstoneCarvingReadDto>> CreateOne(GemstoneCarvingCreateDto createDto)
        {
            var newCarving = await _gemstoneCarvingService.CreateOneAsync(createDto);
            return Ok(newCarving);
        }


        [HttpPut("{carvingId}")]
        public async Task<ActionResult> UpdateOne(Guid carvingId, GemstoneCarvingUpdateDto updateDto)
        {
            var carvingUpdate = await _gemstoneCarvingService.UpdateOneAsync(carvingId, updateDto);
            if (carvingUpdate == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(carvingUpdate); // 200 OK 
        }

        [HttpDelete("{carvingId}")]
        public async Task<ActionResult> DeleteOn(Guid carvingId)
        {
            var carvingDeleted = await _gemstoneCarvingService.DeleteOneAsync(carvingId);
            if (carvingDeleted == false)
            {
                return NotFound();
            }
            return NoContent(); // 200 OK 
        }

    }
}