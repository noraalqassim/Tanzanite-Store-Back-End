namespace src.Entity
{
    public class Payment
    {
        public int Payment_id { get; set; }
        public DateTime Payment_date { get; set; }
        public float Amount { get; set; }
        public string Payment_option { get; set; }
    }
}