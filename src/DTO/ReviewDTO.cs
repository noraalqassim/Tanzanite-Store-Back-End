using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static src.DTO.UserDTO;


namespace src.DTO
{
    public class ReviewDTO
    {
  
        public class ReviewCreateDTO
        {
            public int Rating { get; set; }
            public string ReviewComment { get; set; }
            public Guid UserId { get; set; } 
            public Guid OrderId { get; set; }
        }

        public class ReviewReadDTO
        {
            public Guid ReivewId { get; set; }
            public DateTime ReviewDate { get; set; }
            public int ReviewRating { get; set; }
            public string ReviewComment { get; set; }
            public UserReadDto User { get; set; }
            public Guid OrderId { get; set; } 

        }

        public class ReviewUpdateDTO
        {
            public DateTime ReviewDate { get; set; }
            public int ReviewRating { get; set; }
            public string ReviewComment { get; set; }
        }

    }
} 