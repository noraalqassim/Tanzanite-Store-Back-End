using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Services.review;
using Microsoft.AspNetCore.Mvc;
using static src.DTO.ReviewDTO;
using Microsoft.AspNetCore.Authorization;

namespace src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    // api/v1/reviews 
    public class ReviewsController : ControllerBase // ReviewsController inherits from ControllerBase
    {

        /// <summary>
        /// The point of the reviews controller is to act as the entry point for handling HTTP requests related to the product reviews.
        /// It defines endpoints (routes) for clients to interact with the application.
        /// include: create, read, update and delete (GET, POST, PUT, DELETE).
        /// 1- Submit new reviews for products, including ratings and comments.
        /// 2- Retriving a list of reviews
        /// 3- Update review to modify content or ratings
        /// 4- Delete review
        /// </summary>

        // field
        protected readonly IReviewService _reviewService;

        // Constructor for DI (Dependency Injection)
        public ReviewsController(IReviewService service)
        {
            _reviewService = service;
        }

        /// <API>
        ///  {
        ///   "reviewDate": "2024-09-30T11:04:02.252Z",
        ///   "rating": 0,
        ///   "reviewComment": "string",
        ///   "userId": 0,
        ///   "jewelryId": 0
        ///  }
        /// </API>
        /// return review info

        // Create a new review
        [HttpPost]
        [Authorize] // --> For users
        public async Task<ActionResult<ReviewReadDTO>> CreateOne(ReviewCreateDTO createDto)
        {
            var reviewCreated = await _reviewService.CreateOneAsync(createDto);
            return Ok(reviewCreated); // 200 Ok
        }

        // Update a review
        [HttpPut("{id}")]
        [Authorize] // --> For users
        public async Task<ActionResult<ReviewReadDTO>> UpdateOne(Guid id, ReviewUpdateDTO updateDto)
        {
            var reviewUpdated = await _reviewService.UpdateOneAsync(id, updateDto);
            if (reviewUpdated == null)
            {
                return NotFound(); // 404 Not Found
            }
            return Ok(reviewUpdated); // 200 OK 
        }

        /// <API>
        /// [
        ///  {
        ///   "reivewId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///   "reviewDate": "2024-09-30T11:04:02.254Z",
        ///   "reviewRating": 0,
        ///   "reviewComment": "string",
        ///   "userId": 0,
        ///   "jewelryId": 0
        ///  }
        /// ]
        /// </API>
        /// return review info

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

        // Delete a review
        [HttpDelete("{id}")]
        [Authorize] // --> For users
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