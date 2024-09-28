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

        //proudct
        public DbSet<Gemstones_Carvings> Gemstones_Carvings { get; set; }
        public DbSet<Gemstones> Gemstones { get; set; }
        public DbSet<Jewelry> Jewelry { get; set; }

        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships between entities here
            // modelBuilder
            //     .Entity<Users>()
            //     .HasMany(u => u.Address)
            //     .WithOne(a => a.User)
            //     .HasForeignKey(a => a.UserId);
        }
    }
}
