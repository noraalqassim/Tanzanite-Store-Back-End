using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace src.Entity
{
    public class Jewelry
    {
        /// <summary>
        ///  JewelryName property is where you would store the descriptive name or type of the jewelry item, 
        ///  such as "ring," "necklace," "bracelet," or any other specific name that identifies the jewelry piece.
        ///  
        /// JewelryType property is where you would specify the material or type of the jewelry, 
        /// such as "gold," "silver," "Platinum," or any other material that characterizes the jewelry item.
        /// 
        /// JewelryPrice: price associated with the jewelry item itself.
        /// 
        /// Users with the role "admin" to add jewelry items after authentication.
        /// </summary>
        public Guid JewelryId { get; set; }
        public string JewelryName { get; set; } //ring
        public string JewelryType { get; set; } //gold
        public decimal JewelryPrice { get; set; }
        public string JewelryImage { get; set; }
        public string Description { get; set; }
        public ICollection<Gemstones> Gemstone { get; }= []; // many-to-many relationship with Gemstone

        //one to many relationship
        public Guid? OrderProductId { get; set; }
        public OrderGemstone? OrderProducts { get; set; }

    }
}
