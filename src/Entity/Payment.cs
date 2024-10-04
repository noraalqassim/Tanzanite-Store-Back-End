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

        public Guid OrderId { get; set; } 
      
        public Order Order { get; set; } 
    }
}
