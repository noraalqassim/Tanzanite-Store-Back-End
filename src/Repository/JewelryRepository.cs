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
            var jewelry = await _jewelry.Include(j => j.Gemstone).ThenInclude(g => g.Category).ToListAsync();

            return jewelry;
        }

        public async Task<Jewelry?> GetByIdAsync(Guid JewelryId)
        {
            return await _jewelry
                            .Include(j => j.Gemstone).ThenInclude(g => g.Category).FirstOrDefaultAsync(j => j.JewelryId == JewelryId);
        }

        public async Task<bool> DeleteOnAsync(Jewelry jewelry)
        {
            if (jewelry == null)
                return false;

            _jewelry.Remove(jewelry);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOnAsync(Jewelry updateJewelry)
        {
            if (updateJewelry == null)
                return false;

            _jewelry.Update(updateJewelry);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        // Count all products
        public async Task<int> CountAsync()
        {
            return await _databaseContext.Set<Jewelry>().CountAsync();
        }

        public async Task<List<Jewelry>> GetAllwithPagination(PaginationOptions paginationOptions)
        {
            var jewelries = _jewelry.Include(j => j.Gemstone).ThenInclude(g => g.Category).ToList();
            // search
            if (!string.IsNullOrEmpty(paginationOptions.Search))
            {
                jewelries = jewelries
                    .Where(p => p.JewelryName.Contains(paginationOptions.Search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            //Type
            if (!string.IsNullOrEmpty(paginationOptions.Type))
            {
                jewelries = jewelries
                    .Where(p => !string.IsNullOrEmpty(p.JewelryType) &&
                                p.JewelryType.Length > 0 &&
                                char.ToUpper(p.JewelryType[0]) == char.ToUpper(paginationOptions.Type[0]))
                    .ToList();
            }

            // min price
            if (paginationOptions.MinPrice.HasValue && paginationOptions.MinPrice > 0)
            {
                jewelries = jewelries
                    .Where(p => p.JewelryPrice >= paginationOptions.MinPrice)
                    .ToList();
            }
            // max price
            if (paginationOptions.MinPrice.HasValue && paginationOptions.MaxPrice < decimal.MaxValue)
            {
                jewelries = jewelries
                    .Where(p => p.JewelryPrice <= paginationOptions.MaxPrice)
                    .ToList();
            }

            // Apply pagination 
            jewelries = jewelries
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit)
                .ToList();

            return jewelries;
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
