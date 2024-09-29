using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public int CartQuantity { get; set; }
        public double CartPrice { get; set; }

    } // end class
} // end namespace