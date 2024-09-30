using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Entity
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Amount { get; set; }
        public string PaymentOption { get; set; }

        // Foreign key property for Order
        [ForeignKey("Order")]
        public Guid OrderId { get; set; } // Foreign key for Order

        // Navigation property to Order
        public Order? Order { get; set; } // Reference to the Order
        
        public ICollection<PaymentCard> PaymentCard { get; } = new List<PaymentCard>(); // One to many
    }
}
