using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Review
    {
        public int Reivew_Id { get; set; }
        public int Review_Rating { get; set; }
        public DateTime Review_Date { get; set; }
        public string Review_Comment { get; set; }

    }
}