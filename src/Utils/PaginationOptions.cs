namespace src.Utils
{
    public class PaginationOptions
    {
        public int Limit { get; set; }

        public int Offset { get; set; } = 0;

        public string Search { get; set; } = string.Empty;

        //public string SortOrder { get; set; } = string.Empty; // "", "name_desc", "date_desc", "date", "price_desc", "price"

        public double? LowPrice { get; set; } = 0;
        public double? HighPrice { get; set; } = 10000;
    }
}