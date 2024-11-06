using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
using static src.DTO.GemstonesDTO;
using static src.DTO.JewelryDTO;

namespace src.DTO
{
    public class OrderGemstoneDTO
    {
        public class OrderGemstoneCreateDto
        {
            public Guid JewelryId { get; set; }
            public int Quantity { get; set; }
        }

        public class OrderGemstoneReadDto
        {
            public Guid OrderProductId { get; set; }
            public decimal FinalPrice { get; set; }
            public JewelryReadDto Jewelry { get; set; }
        }

        public class OrderGemstoneUpdateDto
        {
            public decimal FinalPrice { get; set; }
            public int Quantity { get; set; }
        }
    }
}
