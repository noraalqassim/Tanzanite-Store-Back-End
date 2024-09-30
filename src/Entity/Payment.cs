using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Entity
{
    /// <summary>
    ///  The Payment class stores information related to the transaction payment.
    ///  
    ///  PaymentId: A unique identifier for each payment record.
    ///  
    ///  PaymentDate: The date and time when the payment was made.
    ///  
    ///  Amount: The total amount paid in the transaction.
    ///  
    ///  PaymentOption: Specifies the type of payment method used, such as "Credit Card" or "Cash".
    ///  
    ///  OrderId: A foreign key linking the payment to an Order entity, ensuring the payment is associated with the correct order.
    ///  
    ///  Order: A navigation property that allows accessing the related Order entity for this payment.
    ///  
    ///  PaymentCard: A collection of PaymentCard entities associated with this payment, allowing one payment to be linked to multiple payment cards (if applicable).
    /// </summary>

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
