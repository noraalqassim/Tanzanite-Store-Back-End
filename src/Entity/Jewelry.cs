using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Jewelry
    {
        public Guid JewelryId { get; set; }
        public string JewelryName { get; set; }
        public string JewelryType { get; set; }
        public string JewelryImage { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int GemstoneId { get; set; }
        public int CarvingId { get; set; }
        public int UserId { get; set; }
    }
}
