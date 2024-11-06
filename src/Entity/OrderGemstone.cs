using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{

    public class OrderGemstone
    {
        [Key]
        public Guid OrderProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public Guid JewelryId { get; set; }
        public Jewelry Jewelry { get; set; }

        public decimal FinalPrice
        {
            get
            {
                if (Jewelry != null)
                {
                    return Jewelry.FinalProductPrice * Quantity;
                }
                return 0; // or any default value you want to return if Jewelry is null
            }
        }
    }
}
