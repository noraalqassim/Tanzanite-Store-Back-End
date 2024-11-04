using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

namespace src.Repository
{
    public class UserRepository
    {
        protected DbSet<Users> _user;
        protected DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _user = databaseContext.Set<Users>();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _user.AnyAsync(u => u.Email == email);
        }
        public async Task<Users> CreateOnAsync(Users newUser)
        {
            await _user.AddAsync(newUser);
            await _databaseContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await _user.Include(o => o.Addresses).ToListAsync();
        }

        public async Task<Users> FindByEmailAsync(string email)
        {
            return await _user.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Users?> GetByIdAsync(Guid userId)
        {
            var user = await _user
                .Include(u => u.Addresses)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            return user;
        }

        public async Task<bool> DeleteOnAsync(Users user)
        {
            _user.Remove(user);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateOnAsync(Users updateUser)
        {
            _user.Update(updateUser);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
