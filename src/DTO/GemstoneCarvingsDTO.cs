using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;

namespace src.DTO
{
    public class GemstoneCarvingsDTO
    {
        // create category
        public class GemstoneCarvingCreateDto
        {
            public string CarvingName { get; set; }
            public decimal Weight { get; set; }
            public decimal CarvingPrice { get; set; }
            public string CarvingInfo { get; set; }
            public string Image { get; set; }
            public Guid UserId { get; set; } 

        }

        // read data = get data
        public class GemstoneCarvingReadDto
        {
            public Guid CarvingId { get; set; }
            public string CarvingName { get; set; }
            public decimal Weight { get; set; }
            public decimal CarvingPrice { get; set; }
            public string CarvingInfo { get; set; }
            public string Image { get; set; }

        }

        // update
        public class GemstoneCarvingUpdateDto
        {
            public string CarvingName { get; set; }
            public decimal Weight { get; set; }
            public decimal CarvingPrice { get; set; }
            public string CarvingInfo { get; set; }
            public string Image { get; set; }

        }
    }
}