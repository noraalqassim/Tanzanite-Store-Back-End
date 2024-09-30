using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Entity
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; } // PK
        public Guid UserId { get; set; } // FK
        public DateTime CreatedAt { get; set; }
        public Guid AddressId { get; set; } // FK

        public List<OrderGemstone> OrderProducts { get; } = new List<OrderGemstone>(); // One to many 

        // One to one relationship with Payment
        [ForeignKey("Payment")]
        public Guid PaymentId { get; set; } // Foreign key property
        public Payment Payment { get; set; } = null!;

        public Review? Review { get; set; } // One to one 
    }
}
