using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;
using Microsoft.EntityFrameworkCore;
using src.Utils;

namespace src.Repository
{
    public class CategoryRepository
    {
        protected DbSet<Category> _category;
        protected DatabaseContext _databaseContext;
        public CategoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _category = databaseContext.Set<Category>();
        }

        public async Task<Category> CreateOneAsync(Category newCategory)
        {
            await _category.AddAsync(newCategory); 
            await _databaseContext.SaveChangesAsync();
            return newCategory; 
        }
        public async Task<List<Category>> GetAllAsync()
        {
            return await _category.ToListAsync(); 
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _category.FindAsync(id); 
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _category.FirstOrDefaultAsync(c =>
                c.CategoryName.ToLower() == name.ToLower()
            );
        }

        public async Task<bool> DeleteOneAsync(Category category)
        {
            _category.Remove(category); 
            await _databaseContext.SaveChangesAsync(); 
            return true;
        }


        public async Task<bool> UpdateOneAsync(Category updateCategory)
        {
            _category.Update(updateCategory); 
            await _databaseContext.SaveChangesAsync();
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