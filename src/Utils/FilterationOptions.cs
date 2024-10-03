namespace src.Utils
{
    public class FilterationOptions
    {
        public string? Name { get; set; } //Gemston CarvingName
        public string? Type { get; set; } //Jewelry JewelryType
        public string? Color { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        // New properties for sorting
        public string? SortBy { get; set; } // e.g., "Price", "Name"
        public bool IsAscending { get; set; } = true; // Default to ascending
    }
}