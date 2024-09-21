using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]

    public class ReviewsController : ControllerBase
    {
        // field
        // in-memory database
        public static List<Review> reviews = new List<Review>
          {
             new Review { Reivew_Id = 1, Review_Rating = 5, Review_Date = new DateTime(2024, 9, 21), Review_Comment = "Very Nice" },
             new Review { Reivew_Id = 2, Review_Rating = 3, Review_Date = new DateTime(2024, 9, 15), Review_Comment = "Good" },
             new Review { Reivew_Id = 3, Review_Rating = 1, Review_Date = new DateTime(2024, 9, 8), Review_Comment = "Bad" }
         };

        // ----- GET ----- 

        // base endpoint: http://localhost:5125/api/v1/reviews
        [HttpGet]
        public ActionResult GetReview() // ActionResult: class - return type of http method
        {
            return Ok(reviews); // 200
        }

        // get by id
        // base endpoint: http://localhost:5125/api/v1/reviews/id/1
        [HttpGet("id/{id}")]
        public ActionResult GetReviewById(int id)
        {
            Review? foundReview = reviews.FirstOrDefault(p => p.Reivew_Id == id);
            if (foundReview == null)
            {
                return NotFound(); // 404
            }
            return Ok(foundReview); // 200
        }
        // get by rating
        // base endpoint: http://localhost:5125/api/v1/reviews/rating/5
        [HttpGet("rating/{number}")]
        public ActionResult GetReviewByRating(int number)
        {
            Review? foundReview = reviews.FirstOrDefault(p => p.Review_Rating == number);
            if (foundReview == null)
            {
                return NotFound(); // 404
            }
            return Ok(foundReview); // 200
        }

        // get by date
        // base endpoint: http://localhost:5125/api/v1/reviews/date/2024-09-21
        [HttpGet("date/{date}")]
        public ActionResult GetReviewByDate(DateTime date)
        {
            Review? foundReview = reviews.FirstOrDefault(p => p.Review_Date.Date == date.Date);
            if (foundReview == null)
            {
                return NotFound(); // 404
            }
            return Ok(foundReview); // 200
        }

        // get by datetype ASC / DESC
        // base endpoint: http://localhost:5125/api/v1/reviews/datetype/ASC
        [HttpGet("datetype/{datetype}")]
        public ActionResult GetReviewByDateType(string datetype)
        {
            if (datetype == "ASC" || datetype == "asc")
            {
                var sortedReviews = reviews.OrderBy(p => p.Review_Date).ToList();
                return Ok(sortedReviews); // 200
            }
            else if (datetype == "DESC" || datetype == "desc")
            {
                var sortedReviews = reviews.OrderByDescending(p => p.Review_Date).ToList();
                return Ok(sortedReviews); // 200
            }
            else
            {
                return NotFound(); // 404
            }
        }

        // ----- POST ----- 

        // base endpoint: http://localhost:5125/api/v1/reviews
        [HttpPost]
        public ActionResult CreateReview(Review newReview)
        {
            reviews.Add(newReview);
            return CreatedAtAction(nameof(GetReviewById), new { id = newReview.Reivew_Id }, newReview); // 201
        }

        // ----- DELETE ----- 

        // base endpoint: http://localhost:5125/api/v1/reviews/1
        [HttpDelete("{id}")]
        public ActionResult DeleteReview(int id)
        {
            Review? foundReview = reviews.FirstOrDefault(p => p.Reivew_Id == id);
            if (foundReview == null)
            {
                return NotFound(); // 404
            }
            reviews.Remove(foundReview);
            return NoContent(); // 204
        }

    }
}