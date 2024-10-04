namespace src.Utils
{
    public class CategoryFilterationOptions
    {
        public string? Name { get; set; }

        // New properties for sorting
        public string? SortBy { get; set; } // e.g., "Price", "Name"
        public bool IsAscending { get; set; } = true; // Default to ascending
    }
}