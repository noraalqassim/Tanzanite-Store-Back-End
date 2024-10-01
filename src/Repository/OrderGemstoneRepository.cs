using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

namespace src.Repository
{
    public class OrderGemstoneRepository
    {
        protected DbSet<OrderGemstone> _orderGemstone;
        private readonly DatabaseContext _context;

        public OrderGemstoneRepository(DatabaseContext context)
        {
            _context = context;
            _orderGemstone = context.Set<OrderGemstone>();
            ;
        }
        //Get all Gemstone order
        public async Task<List<OrderGemstone>> GetAllAsync()
        {
            return await _orderGemstone.ToListAsync();
        }
        //Get one Gemstone order by id
        public async Task<OrderGemstone> GetByIdAsync(Guid OrderProductId)
        {
            return await _orderGemstone.FindAsync(OrderProductId);
        }
        //create
        public async Task<OrderGemstone> CreateOnAsync(OrderGemstone newOrderGemstone)
        {
            await _orderGemstone.AddAsync(newOrderGemstone);
            await _context.SaveChangesAsync();
            return newOrderGemstone;
        }

        //update 
        public async Task<bool> UpdateOnAsync(OrderGemstone updateOrderGemstone)
        {
            _orderGemstone.Update(updateOrderGemstone);
            await _context.SaveChangesAsync();
            return true;
        }

        //Delete 
        public async Task<bool> DeleteOnAsync(OrderGemstone deleteOrderGemstone)
        {
            _orderGemstone.Remove(deleteOrderGemstone);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
