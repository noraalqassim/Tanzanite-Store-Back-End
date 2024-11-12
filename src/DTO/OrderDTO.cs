using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
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
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            public Guid AddressId { get; set; }
            public OrderStatus Status { get; set; }
            public List<OrderGemstoneReadDto> OrderProducts { get; set; }

            public decimal OrderPrice
            {
                get
                {
                    decimal totalOrderPrice = 0;

                    if (OrderProducts != null)
                    {
                        foreach (var orderGemstone in OrderProducts)
                        {
                            totalOrderPrice += orderGemstone.FinalPrice;
                        }
                    }

                    return totalOrderPrice;
                }
            }
        }

        public class OrderUpdateDto
        {
            public OrderStatus Status { get; set; }
        }
    }
}
