namespace src.DTO
{
    public class PaymentDTO
    {

        public class PaymentCreateDto
        {
            public DateTime PaymentDate { get; set; }
            public float Amount { get; set; }
            public string PaymentOption { get; set; }
        }

        public class PaymentReadDto
        {
            public Guid PaymentId { get; set; }
            public DateTime PaymentDate { get; set; }
            public float Amount { get; set; }
            public string PaymentOption { get; set; }
        }

        public class PaymentUpdateDto
        {
            public DateTime PaymentDate { get; set; }
            public float Amount { get; set; }
            public string PaymentOption { get; set; }
        }
    }
}