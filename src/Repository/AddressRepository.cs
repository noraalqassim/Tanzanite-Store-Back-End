using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

namespace src.Repository
{
    public class AddressRepository
    {
        protected DbSet<Address> _addresses;
        protected DatabaseContext _databaseContext;

        public AddressRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _addresses = databaseContext.Set<Address>();
        }

        public async Task<Address> CreateOnAsync(Address newAddress)
        {
            await _addresses.AddAsync(newAddress);
            await _databaseContext.SaveChangesAsync();
            return newAddress;
        }

        public async Task<List<Address>> GetAllAsync()
        {
            return await _addresses.ToListAsync();
        }
          public async Task<List<Address>> GetAllUserAsync()
        {
           
            return await _addresses.ToListAsync();
        }

        public async Task<List<Address>> GetListByIdAsync(Guid userId)
        {
            return await _addresses.Where(a => a.UserId == userId).ToListAsync();
        }

        public async Task<Address> GetByIdAsync(Guid id)
        {
            return await _addresses.FindAsync(id);
        }

        public async Task<bool> DeleteOnAsync(Address address)
        {
            _addresses.Remove(address);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOnAsync(Address address)
        {
            _addresses.Update(address);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
