using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

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




    }
}