using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Gemstones> Gemstone { get; } = new List<Gemstones>(); //one to many Relationship

    } // end class
} // end namespace