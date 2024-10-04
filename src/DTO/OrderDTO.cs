using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.OrderGemstoneDTO;
using static src.DTO.PaymentDTO;
using static src.DTO.ReviewDTO;

namespace src.DTO
{
    public class OrderDTO
    {
       
        public class OrderCreateDto
        {
            public List<OrderGemstoneCreateDto> OrderProducts { get; set; }
        }

        public class OrderReadDto
        {
            public Guid OrderId { get; set; }
            public Guid UserId { get; set; }
            public DateTime CreatedAt { get; set; }
            public Guid AddressId { get; set; }

            public List<OrderGemstoneReadDto> OrderProducts { get; set; }
        }

        public class OrderUpdateDto
        {
            public Guid AddressId { get; set; }
        }
    }
}
