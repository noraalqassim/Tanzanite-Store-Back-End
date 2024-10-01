 using Microsoft.EntityFrameworkCore;
 using src.Entity;
using src.Services.Order;
using System.Collections.Generic;
using System.Linq;
 using System.Threading.Tasks;

namespace src.Repositories
{
    
     public class OrderRepository 
    {         private readonly DbContext _context;

         public OrderRepository(DbContext context)
         {
             _context = context;
         }

        public async Task<IEnumerable<Order>> GetAllOrders()
         {
             return await _context.Set<Order>().ToListAsync();
         }

         public async Task<Order> GetOrder(int id)
         {
             return await _context.Set<Order>().FindAsync(id);
         }

         public async Task<Order> CreateOrder(Order order)
         {
             _context.Set<Order>().Add(order);
             await _context.SaveChangesAsync();
            return order;
         }

         public async Task<Order> UpdateOrder(int id, Order order)
         {
             var existingOrder = await GetOrder(id);
             if (existingOrder != null)
            {
                existingOrder.Serial = order.Serial;
                existingOrder.UserId = order.UserId;
                existingOrder.CreatedAt = order.CreatedAt;
                existingOrder.AddressId = order.AddressId;
             //   existingOrder.OrderProducts = GetOrderProducts(order);

                await _context.SaveChangesAsync();
                return existingOrder;
            }
            return null;
         }

        private static List<OrderGemstone> GetOrderProducts(Order order)
        {
            return order.OrderProducts;
        }

        public async Task DeleteOrder(int id)
         {
             var order = await GetOrder(id);
             if (order != null)
             {
                 _context.Set<Order>().Remove(order);
                 await _context.SaveChangesAsync();
             }
         }

        internal async Task CreateOneAsync(Order.Services order)
        {
            throw new NotImplementedException();
        }

        internal async Task CreateOneAsync(Order order)
        {
            throw new NotImplementedException();
=======
using Microsoft.EntityFrameworkCore;
using src.Database;
using src.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //get all Order
        public async Task<List<Order>> GetAllAsync()
        {
            return await _order.ToListAsync();
        }
        //get order by id
        public async Task<Order> GetByIdAsync(Guid Orderid)
        {
            return await _order.FindAsync(Orderid);
        }

        //Create new order 
        public async Task<Order> CreateOnAsync(Order newOrder)
        {
            await _order.AddAsync(newOrder);
            await _databaseContext.SaveChangesAsync();
            return newOrder;
        }
        //update 
        public async Task<bool> UpdateOnAsync(Order updateOrder)
        {
            _order.Update(updateOrder);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        //Delete 
        public async Task<bool> DeleteOnAsync(Order deleteOrder)
        {
            _order.Remove(deleteOrder);
            await _databaseContext.SaveChangesAsync();
            return true;
        }
    }
}