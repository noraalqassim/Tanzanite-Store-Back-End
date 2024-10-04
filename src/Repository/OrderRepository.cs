using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;

namespace src.Repository
{
    public class OrderRepository
    {
        protected DbSet<Order> _order;
        private readonly DatabaseContext _databaseContext;

        public OrderRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _order = databaseContext.Set<Order>();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            // return await _order.ToListAsync();
            return await _order
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Jewelry)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Gemstone)
                .ToListAsync();
        }

        //Create new order
        public async Task<Order?> CreateOnAsync(Order newOrder)
        {
            await _order.AddAsync(newOrder);
            await _databaseContext.SaveChangesAsync();

            // Get orderGemstone in Order
            await _order.Entry(newOrder).Collection(o => o.OrderProducts).LoadAsync();

            // Get product info from OrderProduct (OrderGemstone)
            foreach (var detail in newOrder.OrderProducts)
            {
                await _databaseContext.Entry(detail).Reference(od => od.Jewelry).LoadAsync();
                await _databaseContext.Entry(detail).Reference(od => od.Gemstone).LoadAsync();

                // Calculate FinalPrice for OrderGemstone
                detail.CalculateFinalPrice();
            }

            return newOrder;
        }

    //     public async Task<List<Order>> GetAllAsync()
    //     {
    //         return await _databaseContext.Orders
    // .Include(o => o.OrderProducts) // Include OrderProducts
    // .ToListAsync();
    //     }
        // //update
        // public async Task<bool> UpdateOnAsync(Order updateOrder)
        // {
        //     _order.Update(updateOrder);
        //     await _databaseContext.SaveChangesAsync();
        //     return true;
        // }

        // //Delete
        // public async Task<bool> DeleteOnAsync(Order deleteOrder)
        // {
        //     _order.Remove(deleteOrder);
        //     await _databaseContext.SaveChangesAsync();
        //     return true;
        // }
    }
}
