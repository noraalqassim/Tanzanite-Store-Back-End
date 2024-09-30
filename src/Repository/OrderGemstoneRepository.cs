// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using src.Database;
// using src.Entity;

// namespace src.Repository
// {
//     public class OrderGemstoneRepository
//     {
//         protected DbSet<OrderGemstone> _orderGemstone;
//         private readonly DatabaseContext _context;

//         public OrderGemstoneRepository(DatabaseContext context)
//         {
//             _context = context;
//             _orderGemstone = context.Set<OrderGemstone>();
//             ;
//         }

//         public async Task<List<OrderGemstone>> GetAllOrderGemstones()
//         {
//             return await _orderGemstone.ToListAsync();
//         }

//         public async Task<OrderGemstone> GetOrderGemstoneById(int id)
//         {
//             return await _orderGemstone.FindAsync(id);
//         }

//         public async Task CreateOrderGemstone(OrderGemstone orderGemstone)
//         {
//             _orderGemstone.Add(orderGemstone);
//             await _context.SaveChangesAsync();
//         }

//         public async Task UpdateOrderGemstone(OrderGemstone orderGemstone)
//         {
//             _orderGemstone.Update(orderGemstone);
//             await _context.SaveChangesAsync();
//         }

//         public async Task DeleteOrderGemstone(int id)
//         {
//             var orderGemstone = await GetOrderGemstoneById(id);
//             if (orderGemstone != null)
//             {
//                 _orderGemstone.Remove(orderGemstone);
//                 await _context.SaveChangesAsync();
//             }
//         }
//     }
// }
