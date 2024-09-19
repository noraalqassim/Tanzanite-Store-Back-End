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
                Gemstone_ID = 1,
                Gemstone_Type = "Diamond",
                Gemstone_Color = "Clear",
                Gemstone_Image = "diamond.jpg",
                Gemstone_Clarity = "Flawless",
                Gemstone_Description = "A precious diamond gemstone.",
            },
            new Gemstones
            {
                Gemstone_ID = 2,
                Gemstone_Type = "Ruby",
                Gemstone_Color = "Red",
                Gemstone_Image = "ruby.jpg",
                Gemstone_Clarity = "Opaque",
                Gemstone_Description = "A beautiful ruby gemstone.",
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
            var gemStoneType = gemstones.FirstOrDefault(item => item.Gemstone_Type == type);

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
            return Created($"/api/v1/gemstones/{newGemstone.Gemstone_ID}", newGemstone);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGemstone(int id)
        {
            var foundGemstone = gemstones.FirstOrDefault(g => g.Gemstone_ID == id);
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
            var foundGemstone = gemstones.FirstOrDefault(g => g.Gemstone_ID == id);
            if (foundGemstone != null)
            {
                foundGemstone.Gemstone_Type = updatedGemstone.Gemstone_Type;
                foundGemstone.Gemstone_Color = updatedGemstone.Gemstone_Color;
                foundGemstone.Gemstone_Image = updatedGemstone.Gemstone_Image;
                foundGemstone.Gemstone_Clarity = updatedGemstone.Gemstone_Clarity;
                foundGemstone.Gemstone_Description = updatedGemstone.Gemstone_Description;
                return Ok(foundGemstone);
            }
            return NotFound();
        }
    }
}
