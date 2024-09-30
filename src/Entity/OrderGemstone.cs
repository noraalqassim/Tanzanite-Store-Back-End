using System.ComponentModel.DataAnnotations;

namespace src.Entity
{
    public class OrderGemstone
    {
        [Key]
        public Guid OrderProductId { get; set; } // PK
        public List<Jewelry> Jewelries { get; } = []; //one to many relationship

        //one to many relationship 
        public Guid CartId { get; set; }
        public Cart Cart { get; set; } = null!;

        //one to many relationship
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        //one to many relationship
        public Guid UserId { get; set; }
        public Users User { get; set; } = null!;



    }
}
