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
        /// <summary>
        /// Data Transfer Object (DTO)
        /// This DTO is designed to encapsulate all necessary information.
        /// transfer data between different parts of an application,
        /// such as between services, and repositories.
        /// Mapper used the class down there.
        /// Contains Review details such as Date, Rating and Comment.
        /// This DTO is designed to encapsulate all necessary information for review creation.
        /// </summary>

        // create review
        public class ReviewCreateDTO
        {
            public DateTime ReviewDate { get; set; }
            public int Rating { get; set; }
            public string ReviewComment { get; set; }
            public Guid UserId { get; set; } // FK
            public Guid OrderId { get; set; } // FK
        }

        // read data = get data
        public class ReviewReadDTO
        {
            public Guid ReivewId { get; set; }
            public DateTime ReviewDate { get; set; }
            public int ReviewRating { get; set; }
            public string ReviewComment { get; set; }
            public Guid UserId { get; set; } // FK
            public Guid OrderId { get; set; } // FK

        }

        // update
        public class ReviewUpdateDTO
        {
            public DateTime ReviewDate { get; set; }
            public int ReviewRating { get; set; }
            public string ReviewComment { get; set; }
            public Guid UserId { get; set; } // FK
            public Guid OrderId { get; set; } // FK
        }

    } // end class
} // end namespace