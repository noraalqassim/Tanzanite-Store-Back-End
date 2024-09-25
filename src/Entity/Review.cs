using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Review
    {
        public Guid ReivewId { get; set; }
        public int ReviewRating { get; set; }
        public DateTime ReviewDate { get; set; }
        public string ReviewComment { get; set; }

    }
}