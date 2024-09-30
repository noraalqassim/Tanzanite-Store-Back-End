using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Order
    {
        public Guid OrderId { get; set; } // PK
        public Guid UserId { get; set; } // FK
        public DateTime CreatedAt { get; set; }
        public Guid AddressId { get; set; } // FK

        public List<OrderGemstone> OrderProducts { get; } = new List<OrderGemstone>(); //one to many 

        //One to one relationship
        public Guid PaymentId { get; set; } // Required foreign key property
        public Payment Payment { get; set; } = null!;

        public Review? Review { get; set; } //One to one 

    }
}
