using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Services.review;
using static src.DTO.ReviewDTO;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReviewsController : ControllerBase
    {
        protected readonly IReviewService _reviewService;

        public ReviewsController(IReviewService service)
        {
            _reviewService = service;
        }

        [HttpPost]
        [Authorize] 
        public async Task<ActionResult<ReviewReadDTO>> CreateOne(ReviewCreateDTO createDto)
        {
            var reviewCreated = await _reviewService.CreateOneAsync(createDto);
            return Ok(reviewCreated); 
        }

        // Update a review
        [HttpPut("{ReviewId}")]
        [Authorize] 
        public async Task<ActionResult<ReviewReadDTO>> UpdateOne(Guid ReviewId, ReviewUpdateDTO updateDto)
        {
            var reviewUpdated = await _reviewService.UpdateOneAsync(ReviewId, updateDto);
            if (reviewUpdated == null)
            {
                return NotFound(); 
            }
            return Ok(reviewUpdated); 
        }

        [HttpGet]
        public async Task<ActionResult<List<ReviewReadDTO>>> GetAll()
        {
            var reviewList = await _reviewService.GetAllAsync();
            return Ok(reviewList); 
        }

        [HttpGet("{ReviewId}")]
        public async Task<ActionResult<ReviewReadDTO>> GetById(Guid ReviewId)
        {
            var review = await _reviewService.GetByIdAsync(ReviewId);
            if (review == null)
            {
                return NotFound(); 
            }
            return Ok(review); 
        }

        [HttpDelete("{id}")]
        [Authorize] 
        public async Task<ActionResult> DeleteOne(Guid id)
        {
            var reviewDeleted = await _reviewService.DeleteOneAsync(id);
            if (reviewDeleted == false)
            {
                return NotFound();
            }
            return NoContent(); 
        }
    } 
} 
