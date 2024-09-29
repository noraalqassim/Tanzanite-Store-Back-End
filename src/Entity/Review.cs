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

        // Foreign key for the User entity (One to many) Relationship
        public Guid UserId { get; set; }
        public Users User { get; set; } = null!;
        public int JewelryId { get; set; } // Foreign Key

        //One to one relationship
        public Guid OrderId { get; set; } // Required foreign key property
        public Order Order { get; set; } = null!;


    } // end class
} // end namespace