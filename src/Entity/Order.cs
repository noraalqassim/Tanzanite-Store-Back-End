using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Order
{
    public int OrderId { get; set; } // PK
    public int Serial { get; set; }
    public int UserId { get; set; } // FK
    public DateTime CreatedAt { get; set; }
    public int AddressId { get; set; } // FK
    public int OrderProductId { get; set; } // FK
}
    }
