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
    public class JewelryController : ControllerBase
    {
        //#### Jewelry ####
        public static List<Jewelry> jewelryItems = new List<Jewelry>
        {
            new Jewelry
            {
                Jewelry_id = 1,
                Jewelry_name = "Diamond Necklace",
                Jewelry_type = "Necklace",
                Jewelry_image = "diamond_necklace.jpg",
                Description = "Stunning diamond necklace",
                Price = 5000.00m,
                gemstone_id = 1,
                Carving_id = 1,
                seller_id = 1,
            },
            new Jewelry
            {
                Jewelry_id = 2,
                Jewelry_name = "Sapphire Ring",
                Jewelry_type = "Ring",
                Jewelry_image = "sapphire_ring.jpg",
                Description = "Beautiful sapphire ring",
                Price = 2500.00m,
                gemstone_id = 2,
                Carving_id = 2,
                seller_id = 2,
            },
        };

        // Endpoint to retrieve all jewelry items
        [HttpGet]
        public ActionResult GetAllJewelryItems()
        {
            if (jewelryItems == null || jewelryItems.Count == 0)
            {
                return NotFound("No jewelry items found");
            }

            return Ok(jewelryItems); //200
        }

        // Endpoint to retrieve a specific jewelry item by name
        [HttpGet("{name}")]
        public ActionResult GetJewelryItemByName(string name)
        {
            var jewelryItem = jewelryItems.FirstOrDefault(item => item.Jewelry_name == name);

            if (jewelryItem == null)
            {
                return NotFound("Jewelry item not found");
            }

            return Ok(jewelryItem);
        }

        // Endpoint to create a new jewelry item
        [HttpPost]
        public ActionResult CreateJewelryItem(Jewelry newJewelry)
        {
            jewelryItems.Add(newJewelry); //200

            return Created("new jewelry item", newJewelry); //201
        }

        // Endpoint to update information for a specific jewelry item
        [HttpPut("{id}")]
        public ActionResult UpdateJewelryItem(int id, Jewelry updatedJewelry)
        {
            var existingJewelry = jewelryItems.FirstOrDefault(j => j.Jewelry_id == id);

            if (existingJewelry == null)
            {
                return NotFound(); //404
            }

            // Update existing jewelry item
            existingJewelry.Jewelry_name = updatedJewelry.Jewelry_name;
            existingJewelry.Jewelry_type = updatedJewelry.Jewelry_type;
            existingJewelry.Jewelry_image = updatedJewelry.Jewelry_image;
            existingJewelry.Description = updatedJewelry.Description;
            existingJewelry.Price = updatedJewelry.Price;
            existingJewelry.gemstone_id = updatedJewelry.gemstone_id;
            existingJewelry.Carving_id = updatedJewelry.Carving_id;
            existingJewelry.seller_id = updatedJewelry.seller_id;

            return Ok(existingJewelry); //204
        }

        // Endpoint to delete a specific jewelry item by ID
        [HttpDelete("{id}")]
        public ActionResult DeleteJewelryItem(int id)
        {
            var jewelryToDelete = jewelryItems.FirstOrDefault(j => j.Jewelry_id == id);

            if (jewelryToDelete == null)
            {
                return NotFound(); //404
            }

            jewelryItems.Remove(jewelryToDelete);

            return NoContent(); //204
        }
    }
}
