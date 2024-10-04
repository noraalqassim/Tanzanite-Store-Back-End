using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
using static src.DTO.OrderDTO;

namespace src.DTO
{
    public class CartDTO
    {
        public class CartCreateDTO
        {
            public double CartPrice { get; set; }
            public int CartQuantity { get; set; }
            public Guid UserId { get; set; }
        }

        public class CartReadDTO
        {
            public Guid Id { get; set; }
            public double CartPrice { get; set; }
            public int CartQuantity { get; set; }
            public Guid UserId { get; set; }
            public List<OrderReadDto> order { get; set; }
        }

        public class CartUpdateDTO
        {
            public double CartPrice { get; set; }
            public int CartQuantity { get; set; }
            public Guid UserId { get; set; } // FK

            public List<Order> order { get; set; } // FK
        }
    }
}
