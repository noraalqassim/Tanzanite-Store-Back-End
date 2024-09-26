namespace src.Entity
{
    public class Gemstones_Carvings
    {
        public Guid CarvingId { get; set; }
        public string CarvingName { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public string CarvingInfo { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
    }
}