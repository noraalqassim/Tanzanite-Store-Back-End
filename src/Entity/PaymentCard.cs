using System.ComponentModel.DataAnnotations;

namespace src.Entity
{
    public class PaymentCard
    {
        [Key]
        public Guid PaymentCardId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CardHolderName { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string BillingAddress { get; set; }

        //one to many relationship
        public Guid PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;
    }
}