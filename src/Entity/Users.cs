using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        public List<Address> Address { get; set; }
        public byte[]? Salt { get; set; }
        public bool IsAdmin { get; set; }
    }
}
