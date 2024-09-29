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
        /// GemstoneColor -> (Pinkish Red, Blood Red, Deep Red, ..etc) 
        /// Gemstone clarity is assessed using a ten-fold microscope, categorizing clarity by identifying internal impurities and surface defects,
        /// impacting the gem's value. Clarity grades include Flawless (FL), Internally Flawless (IF), Very, Very Slightly Included (VVS1/VVS2),
        /// Very Slightly Included (VS1/VS2), Slightly Included (SI1/SI2), and Included (I1/I2/I3).
        /// For exsample the GemstoneName = Rudy , GemstoneType = Pink Ruby , GemstoneColler = Pinkish Red , GemstoneClarity= VVS (Very, Very Slightly Included)
        /// </summary>
        
        [Key]
        public Guid GemstoneId { get; set; }
        public string GemstoneType { get; set; }
        public string GemstoneColor { get; set; }
        public string GemstoneImage { get; set; }
        public string GemstoneClarity { get; set; }
        public string GemstoneDescription { get; set; }

        // Foreign key relationships
        public Guid CarvingId { get; set; } // FK for Gemstones_Carvings
        public Gemstones_Carvings Carving { get; set; }

        public Guid CategoryId { get; set; } // FK for Category
        public Category Category { get; set; }

        public Guid UserId { get; set; } // FK for Users if IsAdmin == true
        public Users User { get; set; }
    }
}
