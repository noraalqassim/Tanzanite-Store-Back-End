using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]

    public class CartsController : ControllerBase
    {
        // field
        // in-memory database
        public static List<Cart> carts = new List<Cart>
          {
             new Cart { Cart_id = 1, Cart_Quantity = 4, Cart_Price = 630.15 },
             new Cart { Cart_id = 2, Cart_Quantity = 2, Cart_Price = 450 },
             new Cart { Cart_id = 3, Cart_Quantity = 1, Cart_Price = 255 }
         };

        // ----- GET ----- 

        // base endpoint: http://localhost:5125/api/v1/carts
        [HttpGet]
        public ActionResult GetCart() // ActionResult: class - return type of http method
        {
            return Ok(carts); // 200
        }

        // get by id
        // base endpoint: http://localhost:5125/api/v1/carts/id/1
        [HttpGet("id/{id}")]
        public ActionResult GetCartById(int id)
        {
            Cart? foundCart = carts.FirstOrDefault(c => c.Cart_id == id);
            if (foundCart == null)
            {
                return NotFound(); // 404
            }
            return Ok(foundCart); // 200
        }

        // ----- POST ----- 

        // base endpoint: http://localhost:5125/api/v1/carts
        [HttpPost]
        public ActionResult CreateCart(Cart newCart)
        {
            carts.Add(newCart);
            return CreatedAtAction(nameof(GetCartById), new { id = newCart.Cart_id }, newCart); // 201
        }

        // ----- DELETE ----- 

        // base endpoint: http://localhost:5125/api/v1/carts/1
        [HttpDelete("{id}")]
        public ActionResult DeleteCart(int id)
        {
            Cart? foundCart = carts.FirstOrDefault(p => p.Cart_id == id);
            if (foundCart == null)
            {
                return NotFound(); // 404
            }
            carts.Remove(foundCart);
            return NoContent(); // 204
        }

        // ----- PUT ----- 

        // base endpoint: http://localhost:5125/api/v1/carts/1
        [HttpPut("{id}")]
        public ActionResult UpdateCart(int id, Cart newCartInfo)
        {
            Cart? foundCart = carts.FirstOrDefault(p => p.Cart_id == id);
            if (foundCart == null)
            {
                return NotFound(); // 404
            }
            foundCart.Cart_Quantity = newCartInfo.Cart_Quantity;
            foundCart.Cart_Price = newCartInfo.Cart_Price;
            return Ok(foundCart); // 200
        }


    }
}