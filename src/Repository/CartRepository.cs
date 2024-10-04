using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Database;
using src.Entity;
using Microsoft.EntityFrameworkCore;

namespace src.Repository
{
    /// <summary>
    /// Repository Acts as the data access layer, responsible for database operations like fetching, saving, updating, and deleting records.
    /// </summary>
    public class CartRepository
    {

        // fields
        protected DbSet<Cart> _cart;
        protected DatabaseContext _databaseContext;

        // Constructor
        public CartRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _cart = databaseContext.Set<Cart>();
        }

        // Create a new cart Asynchronously
        public async Task<Cart> CreateOneAsync(Cart newCart)
        {
            await _cart.AddAsync(newCart); // Add the new cart
            await _databaseContext.SaveChangesAsync(); // Save changes
            return newCart; // return the created cart
        }

        // Get All carts Asynchronously
        // public async Task<List<Cart>> GetAllAsync()
        // {
        //     return await _cart.ToListAsync(); // Return the list of carts
        // }

        public async Task<List<Cart>> GetAllAsync()
        {
            return await _databaseContext.Cart
.Include(o => o.order) // Include OrderProducts
.ToListAsync();
        }


        // Get cart by Id Asynchronously 
        public async Task<Cart?> GetByIdAsync(Guid id)
        {
            return await _cart.FindAsync(id); // find the cart by id, then return it.
        }

        // Delete cart Asynchronously
        // public async Task<bool> DeleteOneAsync(Cart cart)
        // {
        //     _cart.Remove(cart); // Remove the cart
        //     await _databaseContext.SaveChangesAsync(); // Save changes
        //     return true;
        // }

        // Update cart Asynchronously
        public async Task<bool> UpdateOneAsync(Cart updateCart)
        {
            _cart.Update(updateCart); // Update the cart
            await _databaseContext.SaveChangesAsync(); // Save changes
            return true;
        }

    } // end class
} // end namespace