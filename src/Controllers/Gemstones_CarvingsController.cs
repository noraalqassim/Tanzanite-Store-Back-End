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
    public class Gemstones_CarvingsController : ControllerBase
    {
private static List<Gemstones_Carvings> carvings = new List<Gemstones_Carvings>
    {
        new Gemstones_Carvings
        {
            Carving_id = 1,
            Carving_name = "Oval",
            Weight = 2.5m,
            Price = 500.00m,
            Carving_Info = "Elongating the more traditional round brilliant, oval cut gemstones marry classic with modern. With its longer dimensions, oval gems are incredibly elegant on women with smaller hands as they add depth.",
            Image = "Oval_carving.jpg",
            User_id = 1,
        },
        new Gemstones_Carvings
        {
            Carving_id = 2,
            Carving_name = "Pear",
            Weight = 1.8m,
            Price = 300.00m,
            Carving_Info = "Topping jewelry trends right now is the classic but modern pear shape. With a rounded lower half and a sharp top point, a pear cut adds an illusion of length and delicacy to the finger.",
            Image = "Pear_carving.jpg",
            User_id = 2,
        },
        new Gemstones_Carvings
        {
            Carving_id = 3,
            Carving_name = "Emerald",
            Weight = 2.5m,
            Price = 500.00m,
            Carving_Info = "Close in shape to the baguette, the emerald shapes only departure is its cropped corners. Naturally, this gemstone shape most beautifully flatters an emerald gemstone. That said, many choose colored gems for this cut, thanks to its 50 facets that make the color dazzle strikingly.",
            Image = "Emerald_carving.jpg",
            User_id = 1,
        },
        new Gemstones_Carvings
        {
            Carving_id = 4,
            Carving_name = "Heart",
            Weight = 2.5m,
            Price = 500.00m,
            Carving_Info = "Like the name insinuates, heart-shaped gems are cut into a heart by placing a cleft cut at the top of a pear gemstone. The overall aesthetic is romantic and feminine, but it’s not suitable for all gemstones.",
            Image = "Heart_carving.jpg",
            User_id = 3,
        }
    };

//get by id
    [HttpGet]
    public ActionResult GetCarvings()
    {
        if (carvings == null || carvings.Count == 0)
        {
            return NotFound("No carvings found");
        }
        return Ok(carvings);
    }
//git by name 
    [HttpGet("{name}")]
    public ActionResult GetCarvingByName(string name)
    {
        var carving = carvings.FirstOrDefault(c => c.Carving_name == name);
        if (carving == null)
        {
            return NotFound("Carving not found");
        }
        return Ok(carving);
    }
//create new carveing 

    [HttpPost]
    public ActionResult CreateCarving(Gemstones_Carvings newCarving)
    {
        carvings.Add(newCarving);
        return Created($"/api/v1/Gemstones_Carvings/{newCarving.Carving_id}", newCarving);
    }

    //delete carveing by id

    [HttpDelete("{id}")]
    public ActionResult DeleteCarving(int id)
    {
        var foundCarving = carvings.FirstOrDefault(c => c.Carving_id == id);
        if (foundCarving != null)
        {
            carvings.Remove(foundCarving);
            return NoContent();
        }
        return NotFound();
    }

//update carving by id
    [HttpPut("{id}")]
    public ActionResult UpdateCarving(int id, Gemstones_Carvings updatedCarving)
    {
        var foundCarving = carvings.FirstOrDefault(c => c.Carving_id== id);
        if (foundCarving != null)
        {
            foundCarving.Carving_name = updatedCarving.Carving_name;
            foundCarving.Weight = updatedCarving.Weight;
            foundCarving.Price = updatedCarving.Price;
            foundCarving.Carving_Info = updatedCarving.Carving_Info;
            foundCarving.Image = updatedCarving.Image;
            return Ok(foundCarving);
        }
        return NotFound();
    }
    }
}
