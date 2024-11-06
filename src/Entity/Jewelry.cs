using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Jewelry
    {

        public Guid JewelryId { get; set; }
        public string JewelryName { get; set; } //ring
        public string JewelryType { get; set; } //gold
        public decimal JewelryPrice { get; set; }
        public List<string> JewelryImage { get; set; } = new List<string>();
        // public string JewelryImage { get; set; }
        public string Description { get; set; }
        public decimal FinalProductPrice
        {
            get
            {
                if (Gemstone != null)
                {
                    return JewelryPrice + Gemstone.GemstonePrice;
                }
                return JewelryPrice; // If no gemstone is associated
            }
        }
        public Guid GemstoneId { get; set; }
        public Gemstones Gemstone { get; set; } = null!;


    }
}
