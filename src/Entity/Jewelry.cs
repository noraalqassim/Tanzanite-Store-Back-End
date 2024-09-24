using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Jewelry
    {
        public int Jewelry_id { get; set; }
        public string Jewelry_name { get; set; }
        public string Jewelry_type { get; set; }
        public string Jewelry_image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int gemstone_id { get; set; }
        public int Carving_id { get; set; }
        public int seller_id { get; set; }
    }
}
