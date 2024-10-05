using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;
using src.Utils;

namespace src.Repository
{
    public class JewelryRepository
    {
        protected DbSet<Jewelry> _jewelry;
        protected DatabaseContext _databaseContext;

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

        public async Task<List<Jewelry>> GetAllBySearch(PaginationOptions paginationOptions)
        {
            var result = _jewelry.Where(j =>
                j.JewelryName.ToLower().Contains(paginationOptions.Search.ToLower())
            );
            return await result
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit)
                .ToListAsync();
        }

        // Filters Jewelry items based on price range defined in jewelryFilter.
        // Implements pagination as well.
        // Uses AsQueryable for building the query dynamically.
        // Filtering and Sorting
        public async Task<List<src.Entity.Jewelry>> GetAllByFilteringAsync(FilterationOptions jewelryFilter, PaginationOptions paginationOptions)
        {
            var query = _databaseContext.Jewelry.AsQueryable();

            if (jewelryFilter.MinPrice.HasValue)
            {
                query = query.Where(j => j.JewelryPrice >= jewelryFilter.MinPrice.Value);
            }

            if (jewelryFilter.MaxPrice.HasValue)
            {
                query = query.Where(j => j.JewelryPrice <= jewelryFilter.MaxPrice.Value);
            }

            query = query.Skip(paginationOptions.Offset).Take(paginationOptions.Limit);

            return await query.ToListAsync();
        }
    }
}
