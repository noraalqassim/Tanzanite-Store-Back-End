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

        // //get all Order
        // public async Task<List<Order>> GetAllAsync()
        // {
        //     return await _order.ToListAsync();
        // }
        // //get order by id
        // public async Task<Order> GetByIdAsync(Guid Orderid)
        // {
        //     return await _order.FindAsync(Orderid);
        // }
        //  public async Task<Order?> CreateOneAsync(Order createObject)
        //     {
        //         await _orders.AddAsync(createObject);
        //         await _databaseContext.SaveChangesAsync();

        //         // orderReadDto
        //         // step 1: get order detail in order
        //         // await _orders.Entry(createObject).Collection(o => o.OrderDetails).LoadAsync();
        //         // // step 2: get product information from orderDetail

        //         // foreach (var detail in createObject.OrderDetails)
        //         // {
        //         //     await _databaseContext.Entry(detail).Reference(od => od.Product).LoadAsync();
        //         // }

        //         // return createObject;


        //         // use Include
        //         // order - orderDetail - product
        //         var orderWithDetails = await _orders
        //         .Include(o => o.OrderDetails)
        //         .ThenInclude(od => od.Product)
        //         .FirstOrDefaultAsync(o => o.Id == createObject.Id);
        //         return orderWithDetails;

        //     }
        //Create new order
        public async Task<Order?> CreateOnAsync(Order newOrder)
        {
            await _order.AddAsync(newOrder);
            await _databaseContext.SaveChangesAsync();
            //get orderGemston in Order
            await _order.Entry(newOrder).Collection(o => o.OrderProducts).LoadAsync();
            //get product info from OrderProduct(OrderGemstone)
            foreach (var detail in newOrder.OrderProducts)
            {
                await _databaseContext.Entry(detail).Reference(od => od.Jewelry).LoadAsync();
            }

            return newOrder;
        }
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
