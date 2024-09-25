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
    public class GemStoneController : ControllerBase
    {
        private static List<Gemstones> gemstones = new List<Gemstones>
        {
            new Gemstones
            {
                Gemstone_id = 1,
                Gemstone_type = "Diamond",
                Gemstone_color = "Clear",
                Gemstone_image = "diamond.jpg",
                Gemstone_clarity = "Flawless",
                Gemstone_description = "A precious diamond gemstone.",
                Category_id = 1,
                Carving_id = 1,
                User_id = 1,
            },
            new Gemstones
            {
                Gemstone_id = 2,
                Gemstone_type = "Ruby",
                Gemstone_color = "Red",
                Gemstone_image = "ruby.jpg",
                Gemstone_clarity = "Opaque",
                Gemstone_description = "A beautiful ruby gemstone.",
                Carving_id =1,
                Category_id = 1,
                User_id = 2,
            },
        };

        [HttpGet]
        public ActionResult GetGemstones()
        {
            if (gemstones == null || gemstones.Count == 0)
            {
                return NotFound("No gemstones found");
            }
            return Ok(gemstones);
        }

        //return GemStone by Type
        [HttpGet("{type}")]
        public ActionResult GetGemstonesByType(string type)
        {
            var gemStoneType = gemstones.FirstOrDefault(item => item.Gemstone_type == type);

            if (gemstones == null)
            {
                return NotFound("GemStone Type not found");
            }

            return Ok(gemStoneType);
        }

        [HttpPost]
        public ActionResult CreateGemstone(Gemstones newGemstone)
        {
            gemstones.Add(newGemstone);
            return Created($"/api/v1/gemstones/{newGemstone.Gemstone_id}", newGemstone);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGemstone(int id)
        {
            var foundGemstone = gemstones.FirstOrDefault(g => g.Gemstone_id == id);
            if (foundGemstone != null)
            {
                gemstones.Remove(foundGemstone);
                return NoContent();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateGemstone(int id, Gemstones updatedGemstone)
        {
            var foundGemstone = gemstones.FirstOrDefault(g => g.Gemstone_id == id);
            if (foundGemstone != null)
            {
                foundGemstone.Gemstone_type = updatedGemstone.Gemstone_type;
                foundGemstone.Gemstone_color = updatedGemstone.Gemstone_color;
                foundGemstone.Gemstone_image = updatedGemstone.Gemstone_image;
                foundGemstone.Gemstone_clarity = updatedGemstone.Gemstone_clarity;
                foundGemstone.Gemstone_description = updatedGemstone.Gemstone_description;
                return Ok(foundGemstone);
            }
            return NotFound();
        }
    }
}
