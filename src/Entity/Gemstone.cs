namespace src.Entity
{
    public class Gemstones
    {
        public int Gemstone_id { get; set; }
        public string Gemstone_type { get; set; }
        public string Gemstone_color { get; set; }
        public string Gemstone_image { get; set; }
        public string Gemstone_clarity { get; set; }
        public string Gemstone_description { get; set; }
        public int Carving_id { get; set; }
        public int Category_id { get; set; }
        public int User_id { get; set; }
    }
}
