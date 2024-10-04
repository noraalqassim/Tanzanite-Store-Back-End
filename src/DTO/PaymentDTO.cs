namespace src.DTO
{
    public class PaymentDTO
    {
        public class PaymentCreateDto
        {
            public string PaymentOption { get; set; }
            public DateTime ExpiryDate { get; set; }
            public string CardHolderName { get; set; }
            public string CardType { get; set; }
            public string CardNumber { get; set; }
            public string BillingAddress { get; set; }
            public Guid OrderId { get; set; } 
        }

        public class PaymentReadDto
        {
            public Guid PaymentId { get; set; }
            public DateTime PaymentDate { get; set; }
            public Guid OrderId { get; set; } 
        }

        public class PaymentUpdateDto
        {
            public DateTime PaymentDate { get; set; }
            public float Amount { get; set; }
            public string PaymentOption { get; set; }
        }
    }
}
