using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Gemstones
    {
        /// <summary>
        /// Explanation of the attributes of the Gemstones entity: 
        /// Gemstone Name its the Category like (Ruby,Emerald,Sapphire,...etc)
        /// and the GemstoneType -> (Burmese Ruby, “Pink” Ruby, and Star Ruby ..etc)
        /// 
        /// GemstoneColor -> (Pinkish Red, Blood Red, Deep Red, ..etc) 
        /// 
        /// Gemstone clarity is assessed using a ten-fold microscope, categorizing clarity by identifying internal impurities and surface defects,
        /// impacting the gem's value. Clarity grades include Flawless (FL), Internally Flawless (IF), Very, Very Slightly Included (VVS1/VVS2),
        /// Very Slightly Included (VS1/VS2), Slightly Included (SI1/SI2), and Included (I1/I2/I3).
        /// 
        /// GemstonPrice -> the price of a particular gemstone is based on various factors such as its type, color, clarity, rarity, and quality.
        /// 
        /// For example the GemstoneName = Rudy , GemstoneType = Pink Ruby , GemstoneColler = Pinkish Red , GemstoneClarity= VVS (Very, Very Slightly Included), GemstonPrice =  5,000
        /// 
        /// Users with the role "admin" to add jewelry items after authentication.
        /// </summary>

        [Key]
        public Guid GemstoneId { get; set; }
        public string GemstoneType { get; set; }
        public string GemstoneColor { get; set; }
        public string GemstoneImage { get; set; }
        public string GemstoneClarity { get; set; }
        public decimal GemstonePrice { get; set; }
        public string GemstoneDescription { get; set; }
        public ICollection<Gemstones_Carvings> Carving { get; set; } // Navigation property referencing Gemstones_Carvings
        public List<Jewelry> Jewelries { get; } = [];//many-to-many relationship
        public Guid CategoryId { get; set; }//One-to-many relationship
        public Category Category { get; set; } = null!; //One-to-many relationship

    }
}
