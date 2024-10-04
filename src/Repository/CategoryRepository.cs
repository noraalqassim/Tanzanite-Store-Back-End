using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Database;
using src.Entity;
using Microsoft.EntityFrameworkCore;
using src.Utils;

namespace src.Repository
{
    /// <summary>
    /// Repository Acts as the data access layer, responsible for database operations like fetching, saving, updating, and deleting records.
    /// </summary>
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

        // Get category by Name Asynchronously 
        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _category.FirstOrDefaultAsync(c => c.CategoryName.ToLower() == name.ToLower());
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

        public async Task<List<src.Entity.Category>> GetAllByFilteringAsync(CategoryFilterationOptions categoryFilter, PaginationOptions paginationOptions)
        {
            var query = _databaseContext.Category.AsQueryable();

            if (!string.IsNullOrEmpty(categoryFilter.Name))
            {
                var filterName = categoryFilter.Name.ToLower(); 
                query = query.Where(c => c.CategoryName.ToLower() == filterName);
            }
            query = query.Skip(paginationOptions.Offset).Take(paginationOptions.Limit);

            return await query.ToListAsync();
        }
    } 
} 