using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace src.Entity
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid AddressId { get; set; }

        public List<OrderGemstone> OrderProducts { get; set; }

        public Guid? CartId { get; set; }
        public Cart? Cart { get; set; } = null!;

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
    }
}
