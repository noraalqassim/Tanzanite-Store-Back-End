using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Gemstones
    {
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
