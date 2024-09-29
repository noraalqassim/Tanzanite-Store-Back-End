using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Review
    {

        [Key] // primary key
        public Guid ReviewId { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ReviewRating { get; set; }
        public string ReviewComment { get; set; }
        public int UserId { get; set; } // Foreign Key
        public int JewelryId { get; set; } // Foreign Key

    } // end class
} // end namespace