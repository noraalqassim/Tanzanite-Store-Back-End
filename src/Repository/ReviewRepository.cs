using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Database;
using src.Entity;
using Microsoft.EntityFrameworkCore;

namespace src.Repository
{
    /// <summary>
    /// Repository Acts as the data access layer, responsible for database operations like fetching, saving, updating, and deleting records.
    /// </summary>
    public class ReviewRepository
    {

        // fields
        protected DbSet<Review> _review;
        protected DatabaseContext _databaseContext;

        // Constructor
        public ReviewRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _review = databaseContext.Set<Review>();
        }

        // Create a new review Asynchronously
        public async Task<Review> CreateOneAsync(Review newReview)
        {
            await _review.AddAsync(newReview); // Add the new review
            await _databaseContext.SaveChangesAsync(); // Save changes
            return newReview; // return the created review
        }

        // Get All reviews Asynchronously
        public async Task<List<Review>> GetAllAsync()
        {
            return await _review.ToListAsync(); // Return the list of reviews
        }

        // Get review by Id Asynchronously 
        public async Task<Review?> GetByIdAsync(Guid id)
        {
            return await _review.FindAsync(id); // find the review by id, then return it.
        }

        // Delete review Asynchronously
        public async Task<bool> DeleteOneAsync(Review review)
        {
            _review.Remove(review); // Remove the review
            await _databaseContext.SaveChangesAsync(); // Save changes
            return true;
        }

        // Update review Asynchronously
        public async Task<bool> UpdateOneAsync(Review updateReview)
        {
            _review.Update(updateReview); // Update the review
            await _databaseContext.SaveChangesAsync(); // Save changes
            return true;
        }

    } // end class
} // end namespace