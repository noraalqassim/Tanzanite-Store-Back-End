using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
using static src.DTO.GemstonesDTO;

namespace src.DTO
{
    public class JewelryDTO
    {
        public class JewelryListDto
        {
            public List<JewelryReadDto> Jewelry { get; set; }
            public int TotalCount { get; set; }
        }
        public class JewelryCreateDto
        {
            public string JewelryName { get; set; }
            public string JewelryType { get; set; }
            public decimal JewelryPrice { get; set; }
            public List<string> JewelryImage { get; set; }
            public string Description { get; set; }
            public Guid GemstoneId { get; set; }
        }

        public class JewelryReadDto
        {
            public Guid JewelryId { get; set; }
            public string JewelryName { get; set; }
            public string JewelryType { get; set; }
            public decimal JewelryPrice { get; set; }
            public List<string> JewelryImage { get; set; }
            public string Description { get; set; }
            public GemstoneReadDto Gemstone { get; set; }
        }

        public class JewelryUpdateDto
        {
            public string JewelryName { get; set; }
            public string JewelryType { get; set; }
            public decimal JewelryPrice { get; set; }
            public List<string> JewelryImage { get; set; }
            public string Description { get; set; }
            public Guid GemstoneId { get; set; }
        }
    }
}
