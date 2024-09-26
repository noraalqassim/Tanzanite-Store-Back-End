using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entity
{
    public class Gemstones
    {
        [Key]
        public Guid GemstoneId { get; set; }
        public string GemstoneType { get; set; }
        public string GemstoneColor { get; set; }
        public string GemstoneImage { get; set; }
        public string GemstoneClarity { get; set; }
        public string GemstoneDescription { get; set; }
        public int CarvingId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; } //if IsAdmin == true
    }
}
