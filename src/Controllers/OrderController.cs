// using Microsoft.AspNetCore.Mvc;
// using src.Entity;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using src.Services
// using static src.DTO

// namespace src.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class OrderController : ControllerBase
//     {
//         // Dependency injection of the Order repository or service
//         private readonly IOrderService _orderService;

//         public OrderController(IOrderService orderService)
//         {
//             _orderService = orderService;
//         }

//         // GET: api/Order
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
//         {
//             return await _orderService.GetAllOrders();
//         }

//         // GET: api/Order/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<Order>> GetOrder(int id)
//         {
//             return await _orderService.GetOrder(id);
//         }

//         // POST: api/Order
//         [HttpPost]
//         public async Task<ActionResult<Order>> CreateOrder(Order order)
//         {
//             return await _orderService.CreateOrder(order);
//         }

//         // PUT: api/Order/5
//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateOrder(int id, Order order)
//         {
//             return await _orderService.UpdateOrder(id, order);
//         }

//         // DELETE: api/Order/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteOrder(int id)
//         {
//             return await _orderService.DeleteOrder(id);
//         }
//     }
// }