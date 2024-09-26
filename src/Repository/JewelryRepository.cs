using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

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

        public async Task<Jewelry> CreateOnAsync(Jewelry newJewelryItem)
        {
            await _jewelry.AddAsync(newJewelryItem);
            await _databaseContext.SaveChangesAsync();
            return newJewelryItem;
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
    }
}