using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class OrderGemstone
{
    public int OrderProductId { get; set; } // PK
    public int JewelryId { get; set; } // FK
}}
