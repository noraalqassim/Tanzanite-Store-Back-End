using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// DTO (Data Transfer Object):
// Role: Used to transfer data between layers of the application, 
// typically between the controller and service.

namespace src.DTO
{
    public class CartDTO
    {

        // create Cart
        public class CartCreateDTO
        {
            public double CartPrice { get; set; }
            public int CartQuantity { get; set; }
            public int UserId { get; set; } // FK
            public int JewelryId { get; set; } // FK
        }

        // read data = get data
        public class CartReadDTO
        {
            public Guid Id { get; set; }
            public double CartPrice { get; set; }
            public int CartQuantity { get; set; }
            public int UserId { get; set; } // FK
            public int JewelryId { get; set; } // FK
        }

        // update
        public class CartUpdateDTO
        {
            public double CartPrice { get; set; }
            public int CartQuantity { get; set; }
            public int UserId { get; set; } // FK
            public int JewelryId { get; set; } // FK
        }

    } // end class
} // end namespace