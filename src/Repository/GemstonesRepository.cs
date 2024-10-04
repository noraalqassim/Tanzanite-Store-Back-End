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
        protected DatabaseContext _databaseContext; //database 

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
            return await _gemstones.ToListAsync();
        }


        public async Task<Gemstones?> GetByIdAsync(Guid GemstoneId)
        {
            return await _gemstones.FindAsync(GemstoneId);
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

        public async Task<List<Gemstones>> GetAllBySearch(PaginationOptions paginationOptions)
        { // check the naming convention
            var result = _gemstones.Where(j =>
                j.GemstoneType.ToLower().Contains(paginationOptions.Search.ToLower())
            );
            return await result
                .Skip(paginationOptions.Offset)
                .Take(paginationOptions.Limit)
                .ToListAsync();
        }

    }
}