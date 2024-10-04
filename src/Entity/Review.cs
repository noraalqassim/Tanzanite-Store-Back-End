using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Review
    {

        [Key] 
        public Guid ReviewId { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ReviewRating { get; set; }
        public string ReviewComment { get; set; }

        public Guid UserId { get; set; }
        public Users User { get; set; } = null!;

        public Guid OrderId { get; set; } 
        public Order Order { get; set; } = null!;


    } 
} 