// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using src.Entity;

// namespace src.Repository
// {
//     public interface IOrderGemstoneRepository
//     {
//         Task<List<OrderGemstone>> GetAllOrderGemstones();
//         Task<OrderGemstone> GetOrderGemstoneById(int id);
//         Task CreateOrderGemstone(OrderGemstone orderGemstone);
//         Task UpdateOrderGemstone(OrderGemstone orderGemstone);
//         Task DeleteOrderGemstone(int id);
//     }

//     public class OrderGemstoneRepository : IOrderGemstoneRepository
//     {
//         private readonly DbContext _context;

//         public OrderGemstoneRepository(DbContext context)
//         {
//             _context = context;
//         }

//         public async Task<List<OrderGemstone>> GetAllOrderGemstones()
//         {
//             return await _context.OrderGemstones.ToListAsync();
//         }

//         public async Task<OrderGemstone> GetOrderGemstoneById(int id)
//         {
//             return await _context.OrderGemstones.FindAsync(id);
//         }

//         public async Task CreateOrderGemstone(OrderGemstone orderGemstone)
//         {
//             _context.OrderGemstones.Add(orderGemstone);
//             await _context.SaveChangesAsync();
//         }

//         public async Task UpdateOrderGemstone(OrderGemstone orderGemstone)
//         {
//             _context.OrderGemstones.Update(orderGemstone);
//             await _context.SaveChangesAsync();
//         }

//         public async Task DeleteOrderGemstone(int id)
//         {
//             var orderGemstone = await GetOrderGemstoneById(id);
//             if (orderGemstone != null)
//             {
//                 _context.OrderGemstones.Remove(orderGemstone);
//                 await _context.SaveChangesAsync();
//             }
//         }
//     }
// }