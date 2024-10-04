namespace src.Utils
{
    public class PaginationOptions
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string Search { get; set; } = string.Empty;

    }
}