using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace src.Entity
{
    public class Jewelry
    {
        [Key]
        public Guid JewelryId { get; set; }
        public string JewelryName { get; set; } //ring
        public string JewelryType { get; set; } //gold
        public string JewelryImage { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<Gemstones> Gemstone { get; set; } // Navigation property for the many-to-many relationship with Gemstone

        //one to many relationship
        public Guid OrderProductId { get; set; }
        public OrderGemstone OrderProducts { get; set; }

    }
}
