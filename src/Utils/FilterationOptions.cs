namespace src.Utils
{
    public class FilterationOptions
    {

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        // New properties for sorting
        public string? SortBy { get; set; } // e.g., "Price", "Name"
        public bool IsAscending { get; set; } = true; // Default to ascending
    }
}