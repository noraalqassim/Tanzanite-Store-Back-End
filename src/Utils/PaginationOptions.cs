namespace src.Utils
{
    public class PaginationOptions
    {
        public int Limit { get; set; } = 4;
        public int Offset { get; set; } = 0;
        public string? Search { get; set; } = null;
        public decimal? MinPrice { get; set; } = 0;
        public decimal? MaxPrice { get; set; } = 10000;

    }
}