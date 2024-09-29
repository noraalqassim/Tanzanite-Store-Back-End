using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using src.Entity;

namespace src.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Order { get; set; }
        //proudct
        public DbSet<Gemstones_Carvings> Gemstones_Carvings { get; set; }
        public DbSet<Gemstones> Gemstones { get; set; }
        public DbSet<Jewelry> Jewelry { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options) { }



    }
}
