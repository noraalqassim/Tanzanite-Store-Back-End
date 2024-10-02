using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
using static src.DTO.JewelryDTO;

namespace src.DTO
{
    public class OrderGemstoneDTO
    {
        /// <summary>
        /// Data Transfer Object (DTO)
        /// This DTO is designed to encapsulate all necessary information.
        /// transfer data between different parts of an application,
        /// such as between services, and repositories.
        /// Mapper used the class down there.
        /// Contains order gemstone details such as OrderProductId, FinalPrice.
        /// This DTO is designed to encapsulate all necessary information for OrderGemstone creation.
        /// </summary> 
        public class OrderGemstoneCreateDto
        {
            public Guid JewelryId { get; set; }
            public decimal FinalPrice { get; set; }
            public int Quantity { get; set; }
        }

        public class OrderGemstoneReadDto
        {
            public Guid OrderProductId { get; set; }
            public decimal FinalPrice { get; set; }
            // public List<Jewelry> Jewelries { get; } = new List<Jewelry>();
            public JewelryReadDto Jewelry { get; set; }
        }

        public class OrderGemstoneUpdateDto
        {
            public decimal FinalPrice { get; set; }
            public int Quantity { get; set; }
        }

        // public class JewelryReadDto
        // {
        //     public Guid JewelryId { get; set; }
        //     // Add other properties specific to Jewelry here
        // }
    }
}