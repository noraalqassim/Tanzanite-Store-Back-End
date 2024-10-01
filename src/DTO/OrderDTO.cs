using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.DTO
{
    public class OrderDTO
    {
        /// <summary>
        /// Data Transfer Object (DTO)
        /// This DTO is designed to encapsulate all necessary information.
        /// transfer data between different parts of an application,
        /// such as between services, and repositories.
        /// Mapper used the class down there.
        /// Contains order details such as UserId, CreatedAt, AddressId.
        /// This DTO is designed to encapsulate all necessary information for Order creation.
        /// </summary>
        public class OrderCreateDto
        {
            public Guid UserId { get; set; }
            public DateTime CreatedAt { get; set; }
            public Guid AddressId { get; set; }
        }

        public class OrderReadDto
        {
            public Guid OrderId { get; set; }
            public Guid UserId { get; set; }
            public DateTime CreatedAt { get; set; }
            public Guid AddressId { get; set; }
            public List<OrderGemstoneReadDto> OrderProducts { get; set; }
            public PaymentReadDto Payment { get; set; }
            public ReviewReadDto? Review { get; set; }
        }

        public class OrderUpdateDto
        {
            public DateTime CreatedAt { get; set; }
            public Guid AddressId { get; set; }
        }

        public class OrderGemstoneReadDto
        {
            public Guid OrderId { get; set; }
            public Guid GemstoneId { get; set; }
            // Add other properties specific to OrderGemstone here
        }

        public class PaymentReadDto
        {
            public Guid PaymentId { get; set; }
            public decimal Amount { get; set; }
            // Add other properties specific to Payment here
        }

        public class ReviewReadDto
        {
            public Guid ReviewId { get; set; }
            public string Comment { get; set; }
            // Add other properties specific to Review here
        }
    }
}