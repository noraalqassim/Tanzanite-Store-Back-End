using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Sellers : Users
    {
        public int SellerId { get; set; }
        public int UserId { get; set; }
    }
}
