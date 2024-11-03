using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
using static src.DTO.CategoryDTO;

namespace src.DTO
{
    public class GemstonesDTO
    {

        public class JewelryListDto
        {
            public List<GemstoneReadDto> Gemstones { get; set; }
            public int TotalCount { get; set; }
        }
        public class GemstoneListDto
        {
            public List<GemstoneReadDto> Gemstones { get; set; }
            public int TotalCount { get; set; }
        }
        public class GemstoneCreateDto
        {
            public string GemstoneType { get; set; }
            public string GemstoneColor { get; set; }
            public List<string> GemstoneImages { get; set; }
            public string CarvingName { get; set; }
            public decimal Weight { get; set; }
            public string GemstoneClarity { get; set; }
            public decimal GemstonePrice { get; set; }
            public string GemstoneDescription { get; set; }
            public Guid CategoryId { get; set; }


        }

        public class GemstoneReadDto
        {
            public Guid GemstoneId { get; set; }
            public string GemstoneType { get; set; }
            public string GemstoneColor { get; set; }
            public string CarvingName { get; set; }
            public decimal Weight { get; set; }
            public List<string> GemstoneImages { get; set; }
            public string GemstoneClarity { get; set; }
            public decimal GemstonePrice { get; set; }
            public string GemstoneDescription { get; set; }
            public CategoryReadDto Category { get; set; }
        }

        public class GemstoneUpdateDto
        {
            public string GemstoneType { get; set; }
            public string GemstoneColor { get; set; }
            public List<string> GemstoneImages { get; set; }
            public string CarvingName { get; set; }
            public decimal Weight { get; set; }
            public string GemstoneClarity { get; set; }
            public decimal GemstonePrice { get; set; }
            public string GemstoneDescription { get; set; }

        }
    }
}