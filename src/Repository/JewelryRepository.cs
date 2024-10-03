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
    public class JewelryRepository
    {
        // Jewkry table
        protected DbSet<Jewelry> _jewelry;
        protected DatabaseContext _databaseContext; //database 

        public JewelryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _jewelry = databaseContext.Set<Jewelry>();
        }

        public async Task<Jewelry> CreateOneAsync(Jewelry newJewelryItem)
        {
            await _jewelry.AddAsync(newJewelryItem);
            await _databaseContext.SaveChangesAsync();
            return newJewelryItem;
        }

        public async Task<List<Jewelry>> GetAllAsync()
        {
            return await _jewelry.ToListAsync();
        }

        public async Task<Jewelry?> GetByIdAsync(Guid JewelryId)
        {
            return await _jewelry.FindAsync(JewelryId);
        }

        public async Task<bool> DeleteOnAsync(Jewelry jewelry)
        {
            _jewelry.Remove(jewelry);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOnAsync(Jewelry updateJewelry)
        {
            _jewelry.Update(updateJewelry);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Jewelry>> GetByNameAsync(string searchJewelry)
        {
            return await _databaseContext.Jewelry
                .Where(j => j.JewelryName.ToLower().Contains(searchJewelry.ToLower()))
                .ToListAsync();
        }

        public async Task<List<Jewelry>> GetAllBySearch(PaginationOptions paginationOptions)
        { // check the naming convention
            var result = _jewelry.Where(j =>
                j.JewelryName.ToLower().Contains(paginationOptions.Search.ToLower())
            );
            return await result
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit)
                .ToListAsync();
        }

        public async Task<List<Jewelry>> GetAllByFilteringAsync(FilterationOptions filter)
        {
            IQueryable<Jewelry> queryFilter = _jewelry;

            if (!string.IsNullOrEmpty(filter.Name))
            {
                queryFilter = queryFilter.Where(j => j.JewelryName.ToLower() == filter.Name.ToLower());
            }

            if (filter.MinPrice.HasValue)
            {
                queryFilter = queryFilter.Where(j => j.JewelryPrice <= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                queryFilter = queryFilter.Where(j => j.JewelryPrice >= filter.MaxPrice.Value);
            }

            return await queryFilter.ToListAsync();
        }



    }
}