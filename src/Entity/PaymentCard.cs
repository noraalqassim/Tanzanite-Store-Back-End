namespace src.Entity
{
    public class PaymentCard
    {
        public int PaymentCard_id { get; set; }
        public DateTime ExpiryDate { get; set; }
        public float Balance { get; set; }
        public string CardHolderName { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string BillingAddress { get; set; }
    }
}