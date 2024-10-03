using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace src.Entity
{

    /// <summary>
    /// OrderGemston its Order Details
    /// The "FinalPrice" property appears to represent the total price of the order, 
    /// which includes the prices of jewelry items, gemstones, and carvings.
    /// </summary>
    public class OrderGemstone
    {
        [Key]
        public Guid OrderProductId { get; set; } // PK
        public Guid OrderId { get; set; }
        public decimal FinalPrice { get; set; } // JewelryPrice + GemstonePrice 
        public int Quantity { get; set; }

        // public List<Jewelry> Jewelries { get; } = []; //one to many relationship 
        //public List<Jewelry> Jewelries { get; } = new List<Jewelry>(); //one to many relationship 
        public Guid JewelryId { get; set; }
        public Jewelry Jewelry { get; set; }

        // //one to many relationship 
        // public Guid CartId { get; set; }
        // public Cart Cart { get; set; } = null!;
    }
}
