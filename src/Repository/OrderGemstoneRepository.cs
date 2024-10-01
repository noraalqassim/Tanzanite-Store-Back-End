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
        private readonly DatabaseContext _databaseContext;

        public OrderGemstoneRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _orderGemstone = databaseContext.Set<OrderGemstone>();
            ;
        }
        //get all Order
        public async Task<List<OrderGemstone>> GetAllAsync()
        {
            return await _orderGemstone.ToListAsync();
        }
        //get order by id
        public async Task<OrderGemstone> GetByIdAsync(Guid OrderProductId)
        {
            return await _orderGemstone.FindAsync(OrderProductId);
        }

        //Create new order 
        public async Task<OrderGemstone> CreateOnAsync(OrderGemstone newOrderProduct)
        {
            await _orderGemstone.AddAsync(newOrderProduct);
            await _databaseContext.SaveChangesAsync();
            return newOrderProduct;
        }
        //update 
        public async Task<bool> UpdateOnAsync(OrderGemstone updateOrderGemstone)
        {
            _orderGemstone.Update(updateOrderGemstone);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        //Delete 
        public async Task<bool> DeleteOnAsync(OrderGemstone deleteOrderGemstone)
        {
            _orderGemstone.Remove(deleteOrderGemstone);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
