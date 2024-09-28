using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Services.review;
using Microsoft.AspNetCore.Mvc;
using static src.DTO.ReviewDTO;

// Controller:
// Role: Acts as the entry point for handling HTTP requests. 
// It defines endpoints (routes) for clients to interact with the application.

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    // api/v1/reviews 
    public class ReviewsController : ControllerBase // ReviewsController inherits from ControllerBase
    {

        // field
        protected readonly IReviewService _reviewService;

        // Constructor for DI (Dependency Injection)
        public ReviewsController(IReviewService service)
        {
            _reviewService = service;
        }

        // Create a new review
        [HttpPost]
        public async Task<ActionResult<ReviewReadDTO>> CreateOne(ReviewCreateDTO createDto)
        {
            var reviewCreated = await _reviewService.CreateOneAsync(createDto);
            return Ok(reviewCreated); // 200 Ok
        }

        // Get all reviews
        [HttpGet]
        public async Task<ActionResult<List<ReviewReadDTO>>> GetAll()
        {
            var reviewList = await _reviewService.GetAllAsync();
            return Ok(reviewList); // 200 Ok
        }

        // Get review by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewReadDTO>> GetById(Guid id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(review); // 200 OK 
        }

        // Update a review
        [HttpPut("{id}")]
        public async Task<ActionResult<ReviewReadDTO>> UpdateOne(Guid id, ReviewUpdateDTO updateDto)
        {
            var reviewUpdated = await _reviewService.UpdateOneAsync(id, updateDto);
            if (reviewUpdated == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(reviewUpdated); // 200 OK 
        }

        // Delete a review
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOne(Guid id)
        {
            var reviewDeleted = await _reviewService.DeleteOneAsync(id);
            if (reviewDeleted == false)
            {
                return NotFound(); // 404 Not Found
            }
            return NoContent(); // 200 OK 
        }

    } // end class
} // end namespace