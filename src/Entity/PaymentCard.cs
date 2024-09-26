using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class PaymentCard
    {
        public Guid PaymentCardId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public float Balance { get; set; }
        public string CardHolderName { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string BillingAddress { get; set; }
    }
}