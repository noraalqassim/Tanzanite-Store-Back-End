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