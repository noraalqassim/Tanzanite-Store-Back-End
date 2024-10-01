using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            public decimal FinalPrice { get; set; }
        }

        public class OrderGemstoneReadDto
        {
            public Guid OrderProductId { get; set; }
            public decimal FinalPrice { get; set; }
            public List<JewelryReadDto> Jewelries { get; set; }
        }

        public class OrderGemstoneUpdateDto
        {
            public decimal FinalPrice { get; set; }
        }

        public class JewelryReadDto
        {
            public Guid JewelryId { get; set; }
            // Add other properties specific to Jewelry here
        }
    }
}