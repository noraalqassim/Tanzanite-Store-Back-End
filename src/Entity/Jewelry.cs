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
        public string JewelryName { get; set; }
        public string JewelryType { get; set; }
        public string JewelryImage { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
     // Foreign key relationships
        public Guid GemstoneId { get; set; } // FK for Gemstones
        public Gemstones Gemstone { get; set; }

        public Guid CarvingId { get; set; } // FK for Gemstones_Carvings
        public Gemstones_Carvings Carving { get; set; }

        public Guid UserId { get; set; } // FK for Users if IsAdmin == true
        public Users User { get; set; }
    }
}
