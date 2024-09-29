using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;

namespace src.DTO
{
    public class GemstonesDTO
    {
        public class GemstoneCreateDto
        {
            public string GemstoneType { get; set; }
            public string GemstoneColor { get; set; }
            public string GemstoneImage { get; set; }
            public string GemstoneClarity { get; set; }
            public string GemstoneDescription { get; set; }
            public int CarvingId { get; set; }
            public int CategoryId { get; set; }
            public Guid UserId { get; set; }

        }

        // read data = get data
        public class GemstoneReadDto
        {
            public Guid GemstoneId { get; set; }
            public string GemstoneType { get; set; }
            public string GemstoneColor { get; set; }
            public string GemstoneImage { get; set; }
            public string GemstoneClarity { get; set; }
            public string GemstoneDescription { get; set; }

        }

        // update
        public class GemstoneUpdateDto
        {
            public string GemstoneType { get; set; }
            public string GemstoneColor { get; set; }
            public string GemstoneImage { get; set; }
            public string GemstoneClarity { get; set; }
            public string GemstoneDescription { get; set; }

        }
    }
}