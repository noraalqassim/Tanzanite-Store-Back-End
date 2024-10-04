using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{

    public class OrderGemstone
    {
        [Key]
        public Guid OrderProductId { get; set; } 
        public Guid OrderId { get; set; }
        public decimal FinalPrice { get; set; } 
        public int Quantity { get; set; }
        public Guid JewelryId { get; set; }
        public Jewelry Jewelry { get; set; }
        public Guid GemstoneId { get; set; }
        public Gemstones Gemstone { get; set; }


        public void CalculateFinalPrice()
        {
            if (Jewelry != null && Gemstone != null)
            {
                FinalPrice = (Jewelry.JewelryPrice + Gemstone.GemstonePrice) * Quantity;
            }
        }
    }
}
