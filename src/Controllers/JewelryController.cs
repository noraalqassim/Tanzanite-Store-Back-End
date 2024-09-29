using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Entity;
using src.Services.Jewelry;
using static src.DTO.JewelryDTO;

namespace src.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]//api/v1/Jewelry
    public class JewelryController : ControllerBase
    {
        protected readonly IJewelryService _jewelryService;

        public JewelryController(IJewelryService jewelryService)
        {
            _jewelryService = jewelryService;
        }

        // POST: api/v1/Jewelry
        // Create a new jewelry item
        [HttpPost]
        public async Task<ActionResult<JewelryReadDto>> CreateOne(JewelryCreateDto createDto)
        {
            var nweJewelry = await _jewelryService.CreateOneAsync(createDto);
            return Ok(nweJewelry);//200 Ok
        }

        // GET: api/v1/Jewelry
        // Get all jewelry items
        [HttpGet]
        public async Task<ActionResult<List<JewelryReadDto>>> GetAll()
        {
            var jewelryList = await _jewelryService.GetAllAsync();
            return Ok(jewelryList); //200 OK
        }

        // GET: api/v1/Jewelry/{JewelryId}
        // Get a jewelry item by its ID
        [HttpGet("{JewelryId}")]
        public async Task<ActionResult<JewelryReadDto>> GetById(Guid JewelryId)
        {
            var foundJewelry = await _jewelryService.GetByIdAsync(JewelryId);
            if (foundJewelry == null)
            {
                return NotFound("Jewelry item not found"); //400 Not Found
            }
            return Ok(foundJewelry); //200 Ok
        }

        // PUT: api/v1/jewelry/{JewelryId}
        // Update a jewelry item
        [HttpPut("{JewelryId}")]
        public async Task<ActionResult<JewelryReadDto>> UpdateOne(Guid JewelryId, JewelryUpdateDto updateDto)
        {
            var jewelryUpdate = await _jewelryService.UpdateOneAsync(JewelryId, updateDto);
            if (jewelryUpdate == null)
            {
                return NotFound("Jewelry item not found"); //400  Not Found
            }
            return Ok(jewelryUpdate); //200 OK
        }

        // DELETE: api/v1/Jewelry/{JewelryId}
        // Delete a jewelry item by its ID
        [HttpDelete("{JewelryId}")]
        public async Task<ActionResult> DeleteOne(Guid JewelryId)
        {
            var jewelryDeleted = await _jewelryService.DeleteOneAsync(JewelryId);
            if (jewelryDeleted == false)
            {
                return NotFound(); // 404 Not Found
            }
            return NoContent(); // 200 OK 
        }
    }
}