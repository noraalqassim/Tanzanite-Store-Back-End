// using Microsoft.EntityFrameworkCore;
// using src.Entity;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace src.Repositories
// {
//     public interface IOrderRepository
//     {
//         Task<IEnumerable<Order>> GetAllOrders();
//         Task<Order> GetOrder(int id);
//         Task<Order> CreateOrder(Order order);
//         Task<Order> UpdateOrder(int id, Order order);
//         Task DeleteOrder(int id);
//     }

//     public class OrderRepository : IOrderRepository
//     {
//         private readonly DbContext _context;

//         public OrderRepository(DbContext context)
//         {
//             _context = context;
//         }

//         public async Task<IEnumerable<Order>> GetAllOrders()
//         {
//             return await _context.Set<Order>().ToListAsync();
//         }

//         public async Task<Order> GetOrder(int id)
//         {
//             return await _context.Set<Order>().FindAsync(id);
//         }

//         public async Task<Order> CreateOrder(Order order)
//         {
//             _context.Set<Order>().Add(order);
//             await _context.SaveChangesAsync();
//             return order;
//         }

//         public async Task<Order> UpdateOrder(int id, Order order)
//         {
//             var existingOrder = await GetOrder(id);
//             if (existingOrder != null)
//             {
//                 existingOrder.Serial = order.Serial;
//                 existingOrder.UserId = order.UserId;
//                 existingOrder.CreatedAt = order.CreatedAt;
//                 existingOrder.AddressId = order.AddressId;
//                 existingOrder.OrderProductId = order.OrderProductId;

//                 await _context.SaveChangesAsync();
//                 return existingOrder;
//             }
//             return null;
//         }

//         public async Task DeleteOrder(int id)
//         {
//             var order = await GetOrder(id);
//             if (order != null)
//             {
//                 _context.Set<Order>().Remove(order);
//                 await _context.SaveChangesAsync();
//             }
//         }
//     }
// }