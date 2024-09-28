using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public float Amount { get; set; }
        public string PaymentOption { get; set; }
    }
}