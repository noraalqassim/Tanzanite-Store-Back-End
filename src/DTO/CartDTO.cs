using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;

// DTO (Data Transfer Object):
// Role: Used to transfer data between layers of the application, 
// typically between the controller and service.

namespace src.DTO
{
    public class CartDTO
    {
        /// <summary>
        /// Data Transfer Object (DTO)
        /// This DTO is designed to encapsulate all necessary information.
        /// transfer data between different parts of an application,
        /// such as between services, and repositories.
        /// Mapper used the class down there.
        /// Contains cart details such as Price and Quantity.
        /// This DTO is designed to encapsulate all necessary information for cart creation.
        /// </summary>

        // create Cart
        public class CartCreateDTO
        {
            public double CartPrice { get; set; }
            public int CartQuantity { get; set; }
            public Guid UserId { get; set; } // FK
                                             // public Guid orderId { get; set; } // FK
                                             // public List<OrderGemstone> OrderProducts { get; set; } // FK

            // public List<Order> order { get; set; } // FK

        }

        // read data = get data
        public class CartReadDTO
        {
            public Guid Id { get; set; }
            public double CartPrice { get; set; }
            public int CartQuantity { get; set; }
            public Guid UserId { get; set; } // FK
                                             // public List<OrderGemstone> OrderProducts { get; set; } // FK
            public List<Order> order { get; set; } // FK

        }

        // update
        public class CartUpdateDTO
        {
            public double CartPrice { get; set; }
            public int CartQuantity { get; set; }
            public Guid UserId { get; set; } // FK
                                             // public List<OrderGemstone> OrderProducts { get; set; } // FK
            public List<Order> order { get; set; } // FK

        }

    } // end class
} // end namespace