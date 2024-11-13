using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace src.Entity
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid AddressId { get; set; }

        public List<OrderGemstone> OrderProducts { get; set; }

        public Guid? PaymentId { get; set; }
        public Payment Payment { get; set; } = null!;

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
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered
    }
}
