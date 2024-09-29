using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Database;
using src.Entity;
using Microsoft.EntityFrameworkCore;

// Repository:
// Role: Acts as the data access layer, responsible for database operations like fetching, saving, updating, and deleting records.

namespace src.Repository
{
    public class CategoryRepository
    {

        // fields
        protected DbSet<Category> _category;
        protected DatabaseContext _databaseContext;

        // Constructor
        public CategoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _category = databaseContext.Set<Category>();
        }

        // Create a new category Asynchronously
        public async Task<Category> CreateOneAsync(Category newCategory)
        {
            await _category.AddAsync(newCategory); // Add the new category
            await _databaseContext.SaveChangesAsync(); // Save changes
            return newCategory; // return the created category
        }

        // Get All categories Asynchronously
        public async Task<List<Category>> GetAllAsync()
        {
            return await _category.ToListAsync(); // Return the list of categories
        }

        // Get category by Id Asynchronously 
        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _category.FindAsync(id); // find the category by id, then return it.
        }

        // Delete category Asynchronously
        public async Task<bool> DeleteOneAsync(Category category)
        {
            _category.Remove(category); // Remove the category
            await _databaseContext.SaveChangesAsync(); // Save changes
            return true;
        }

        // Update category Asynchronously
        public async Task<bool> UpdateOneAsync(Category updateCategory)
        {
            _category.Update(updateCategory); // Update the category
            await _databaseContext.SaveChangesAsync(); // Save changes
            return true;
        }

    } // end class
} // end namespace