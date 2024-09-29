using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;

namespace src.DTO
{
    public class JewelryDTO
    {
        public class JewelryCreateDto
        {
            public string JewelryName { get; set; }
            public string JewelryType { get; set; }
            public string JewelryImage { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public Guid GemstoneId { get; set; }
            public Guid CarvingId { get; set; }
            public Guid UserId { get; set; }

        }

        // read data = get data
        public class JewelryReadDto
        {
        public Guid JewelryId { get; set; }
        public string JewelryName { get; set; }
        public string JewelryType { get; set; }
        public string JewelryImage { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        }

        // update
        public class JewelryUpdateDto
        {

        public string JewelryName { get; set; }
        public string JewelryType { get; set; }
        public string JewelryImage { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        }
    }
}