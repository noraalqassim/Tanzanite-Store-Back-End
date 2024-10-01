// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using src.Entity;
// using src.Repository;

// namespace src.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class OrderGemstoneController : ControllerBase
//     {
//         private readonly IOrderGemstoneRepository _repository;

//         public OrderGemstoneController(IOrderGemstoneRepository repository)
//         {
//             _repository = repository;
//         }

//         [HttpGet]
//         public async Task<ActionResult<List<OrderGemstone>>> GetAllOrderGemstones()
//         {
//             return await _repository.GetAllOrderGemstones();
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<OrderGemstone>> GetOrderGemstoneById(int id)
//         {
//             return await _repository.GetOrderGemstoneById(id);
//         }

//         [HttpPost]
//         public async Task<ActionResult<OrderGemstone>> CreateOrderGemstone(OrderGemstone orderGemstone)
//         {
//             await _repository.CreateOrderGemstone(orderGemstone);
//             return CreatedAtAction(nameof(GetOrderGemstoneById), new { id = orderGemstone.OrderProductId }, orderGemstone);
//         }

//         [HttpPut("{id}")]
//         public async Task<ActionResult> UpdateOrderGemstone(int id, OrderGemstone orderGemstone)
//         {
//             if (id != orderGemstone.OrderProductId)
//             {
//                 return BadRequest();
//             }
//             await _repository.UpdateOrderGemstone(orderGemstone);
//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public async Task<ActionResult> DeleteOrderGemstone(int id)
//         {
//             await _repository.DeleteOrderGemstone(id);
//             return NoContent();
//         }
//     }
// }
