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
    public class GemstonesRepository
    {
        protected DbSet<Gemstones> _gemstones;
        protected DatabaseContext _databaseContext;

        public GemstonesRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _gemstones = databaseContext.Set<Gemstones>();
        }

        public async Task<Gemstones> CreateOnAsync(Gemstones newGemstone)
        {
            await _gemstones.AddAsync(newGemstone);
            await _databaseContext.SaveChangesAsync();
            return newGemstone;
        }

        public async Task<List<Gemstones>> GetAllAsync()
        {
            var gemstones = await _gemstones.Include(g => g.Category).ToListAsync();
            return gemstones;
        }

        public async Task<Gemstones?> GetByIdAsync(Guid GemstoneId)
        {
            return await _gemstones
                            .Include(g => g.Category)
                            .FirstOrDefaultAsync(g => g.GemstoneId == GemstoneId);
        }

        public async Task<bool> DeleteOnAsync(Gemstones Gemstone)
        {
            _gemstones.Remove(Gemstone);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOnAsync(Gemstones updateGemstone)
        {
            _gemstones.Update(updateGemstone);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        // Count all products
        public async Task<int> CountAsync()
        {
            return await _databaseContext.Set<Gemstones>().CountAsync();
        }

        public async Task<List<Gemstones>> GetAllwithPagination(PaginationOptions paginationOptions)
        {
            var gemstones = _gemstones.Include(g => g.Category).ToList();

            // Search
            if (!string.IsNullOrEmpty(paginationOptions.Search))
            {
                gemstones = gemstones
                    .Where(p => p.Category.CategoryName.Contains(paginationOptions.Search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            // Min price
            if (paginationOptions.MinPrice.HasValue && paginationOptions.MinPrice > 0)
            {
                gemstones = gemstones
                    .Where(p => p.GemstonePrice >= paginationOptions.MinPrice)
                    .ToList();
            }

            // Max price
            if (paginationOptions.MaxPrice.HasValue && paginationOptions.MaxPrice < decimal.MaxValue)
            {
                gemstones = gemstones
                    .Where(p => p.GemstonePrice <= paginationOptions.MaxPrice)
                    .ToList();
            }

            // Apply pagination 
            gemstones = gemstones
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit)
                .ToList();

            return gemstones;
        }

    }
}
