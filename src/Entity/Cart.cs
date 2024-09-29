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

        // Foreign key for the User entity (One to One) Relationship
        public Guid UserId { get; set; }
        public Users User { get; set; } = null!;
        public List<OrderGemstone> OrderProducts { get; } = new List<OrderGemstone>(); //one to many 
        

    } // end class
} // end namespace