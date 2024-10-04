using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

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
    } 
} 
