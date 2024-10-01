using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace src.Entity
{

/// <summary>
/// The "FinalPrice" property appears to represent the total price of the order, 
/// which includes the prices of jewelry items, gemstones, and carvings.
/// </summary>
    public class OrderGemstone
    {
        [Key]
        public Guid OrderProductId { get; set; } // PK
        public decimal FinalPrice { get; set; } // JewelryPrice + GemstonePrice + CarvingPrice
        public List<Jewelry> Jewelries { get; } = []; //one to many relationship //one to many relationship
//
//         //one to many relationship 
//         public Guid CartId { get; set; }
//         public Cart Cart { get; set; } = null!;

//         //one to many relationship
//         public Guid OrderId { get; set; }
//         public Order Order { get; set; } = null!;

//         //one to many relationship
//         public Guid UserId { get; set; }
//         public Users User { get; set; } = null!;



    }
}
