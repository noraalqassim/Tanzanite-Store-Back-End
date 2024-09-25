using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Address
    {
        public int Address_id { get; set; }
        public int User_id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string ZipCode { get; set; }
    }
}
