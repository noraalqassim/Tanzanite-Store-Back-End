using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace src.Entity
{
    public class Users
    {
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public byte[]? Salt { get; set; }
        public bool IsAdmin { get; set; }
    }
}
