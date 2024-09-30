using System.ComponentModel.DataAnnotations;

namespace src.Entity
{
    /// <summary>
    ///  The PaymentCard class stores information about individual payment cards used in a transaction.
    ///  
    ///  PaymentCardId: A unique identifier for each payment card record.
    ///  
    ///  ExpiryDate: The expiration date of the payment card.
    ///  
    ///  CardHolderName: The name of the individual who owns the payment card.
    ///  
    ///  CardType: Specifies the type of payment card, such as "Visa," "MasterCard," or "American Express".
    ///  
    ///  CardNumber: The actual card number used for the transaction.
    ///  
    ///  BillingAddress: The address associated with the payment card.
    ///  
    ///  PaymentId: A foreign key linking this payment card to a Payment entity.
    ///  
    ///  Payment: A navigation property that allows accessing the related Payment entity for this card, ensuring the card is correctly associated with a specific payment.
    /// </summary>
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