using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// DTO (Data Transfer Object):
// Role: Used to transfer data between layers of the application, 
// typically between the controller and service.

namespace src.DTO
{
    public class ReviewDTO
    {
        // create review
        public class ReviewCreateDTO
        {
            public DateTime ReviewDate { get; set; }
            public int Rating { get; set; }
            public string ReviewComment { get; set; }
            public int userId { get; set; } // FK
            public int JewelryId { get; set; } // FK
        }

        // read data = get data
        public class ReviewReadDTO
        {
            public Guid ReivewId { get; set; }
            public DateTime ReviewDate { get; set; }
            public int ReviewRating { get; set; }
            public string ReviewComment { get; set; }
            public int userId { get; set; } // FK
            public int JewelryId { get; set; } // FK

        }

        // update
        public class ReviewUpdateDTO
        {
            public DateTime ReviewDate { get; set; }
            public int ReviewRating { get; set; }
            public string ReviewComment { get; set; }
            public int userId { get; set; } // FK
            public int JewelryId { get; set; } // FK
        }

    } // end class
} // end namespace