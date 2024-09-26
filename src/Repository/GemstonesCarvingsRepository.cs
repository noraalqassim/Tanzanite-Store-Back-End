using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

namespace sda_3_online_Backend_Teamwork.src.Repository
{
    public class GemstonesCarvingsRepository
    {
        protected DbSet<Gemstones_Carvings> _carvings;
        protected DatabaseContext _databaseContext; //database 

        public GemstonesCarvingsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _carvings = databaseContext.Set<Gemstones_Carvings>();
        }

        public async Task<Gemstones_Carvings> CreateOnAsync(Gemstones_Carvings newCarving)
        {
            await _carvings.AddAsync(newCarving);
            await _databaseContext.SaveChangesAsync();
            return newCarving;
        }

        public async Task<Gemstones_Carvings?> GetByIdAsync(Guid CarvingId )
        {
            return await _carvings.FindAsync(CarvingId);
        }

        public async Task<bool> DeleteOnAsync(Gemstones_Carvings carving)
        {
            _carvings.Remove(carving);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOnAsync(Gemstones_Carvings updateCarving)
        {
            _carvings.Update(updateCarving);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
        
    }
}