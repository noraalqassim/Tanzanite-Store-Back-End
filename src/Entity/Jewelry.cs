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
        public string JewelryImage { get; set; }
        public string Description { get; set; }
    }
}
