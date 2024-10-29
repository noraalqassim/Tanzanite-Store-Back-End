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
        public string CarvingName { get; set; }
        public decimal Weight { get; set; }
        // public string GemstoneImage { get; set; }
        public List<string> GemstoneImages { get; set; } = new List<string>();
        public string GemstoneClarity { get; set; }
        public decimal GemstonePrice { get; set; }
        public string GemstoneDescription { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
