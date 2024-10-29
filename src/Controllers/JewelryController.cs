using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Entity;
using src.Services.Jewelry;
using src.Utils;
using static src.DTO.JewelryDTO;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JewelryController : ControllerBase
    {
        protected readonly IJewelryService _jewelryService;

        public JewelryController(IJewelryService jewelryService)
        {
            _jewelryService = jewelryService;
        }

        [HttpPost]
        public async Task<ActionResult<JewelryReadDto>> CreateOne(JewelryCreateDto createDto)
        {
            var nweJewelry = await _jewelryService.CreateOneAsync(createDto);
            return Ok(nweJewelry);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<JewelryReadDto>>> GetAll()
        {
            var jewelryList = await _jewelryService.GetAllAsync();

            return Ok(jewelryList);
        }

        [AllowAnonymous]
        [HttpGet("{JewelryId}")]
        public async Task<ActionResult<JewelryReadDto>> GetById(Guid JewelryId)
        {
            var foundJewelry = await _jewelryService.GetByIdAsync(JewelryId);
            if (foundJewelry == null)
            {
                return NotFound("Jewelry item not found");
            }
            return Ok(foundJewelry);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{JewelryId}")]
        public async Task<ActionResult<JewelryReadDto>> UpdateOne(
            Guid JewelryId,
            JewelryUpdateDto updateDto
        )
        {
            var jewelryUpdate = await _jewelryService.UpdateOneAsync(JewelryId, updateDto);
            if (jewelryUpdate == null)
            {
                return NotFound("Jewelry item not found");
            }
            return Ok(jewelryUpdate);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{JewelryId}")]
        public async Task<ActionResult> DeleteOne(Guid JewelryId)
        {
            var jewelryDeleted = await _jewelryService.DeleteOneAsync(JewelryId);
            if (jewelryDeleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("Search")]
        public async Task<ActionResult<List<JewelryListDto>>> GetAllJewelryBySearch(
            [FromQuery] PaginationOptions paginationOptions
        )
        {
            var jewelryList = await _jewelryService.GetAllBySearchAsync(paginationOptions);
            var totalCount = await _jewelryService.CountJewelryAsync();

            var response = new JewelryListDto
            {
                Jewelry = jewelryList,
                TotalCount = totalCount
            };

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("Filter")]
        public async Task<ActionResult<List<Jewelry>>> FilterJe(
            [FromQuery] FilterationOptions jewelryFilter,
            [FromQuery] PaginationOptions paginationOptions
        )
        {
            var jewelries = await _jewelryService.GetAllByFilterationAsync(
                jewelryFilter,
                paginationOptions
            );

            return Ok(jewelries);
        }
    }
}
