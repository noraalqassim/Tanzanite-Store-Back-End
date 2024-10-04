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

        public async Task<List<Jewelry>> GetByNameAsync(PaginationOptions paginationOptions)
        {
            var result = _jewelry.Where(j =>
                j.JewelryName.ToLower().Contains(paginationOptions.Search.ToLower())
            ).ToList();

            return await Task.FromResult(result);
        }

        //Searsh By name with paging
        public async Task<List<Jewelry>> GetAllBySearch(PaginationOptions paginationOptions)
        {
            // check the naming convention
            var result = _jewelry.Where(j =>
                j.JewelryName.ToLower().Contains(paginationOptions.Search.ToLower())
            );
            return await result
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit)
                .ToListAsync();
        }

        // Filtering and Sorting
        public async Task<List<src.Entity.Jewelry>> GetAllByFilteringAsync(FilterationOptions jewelryFilter)
        {
            var query = _databaseContext.Jewelry.AsQueryable();

            if (!string.IsNullOrEmpty(jewelryFilter.Type))
            {
                query = query.Where(j => j.JewelryType.Contains(jewelryFilter.Type));
            }

            if (jewelryFilter.MinPrice.HasValue)
            {
                query = query.Where(j => j.JewelryPrice >= jewelryFilter.MinPrice.Value);
            }

            if (jewelryFilter.MaxPrice.HasValue)
            {
                query = query.Where(j => j.JewelryPrice <= jewelryFilter.MaxPrice.Value);
            }

            return await query.ToListAsync();
        }

    }
}