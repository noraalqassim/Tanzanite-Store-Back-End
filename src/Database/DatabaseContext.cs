using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using src.Entity;

// Database Folder:
// Role: This folder often holds classes or configurations related to database setup

namespace src.Database
{
    public class DatabaseContext : DbContext // DatabaseContext inherits from DbContext
    {
        public DbSet<Users> User { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Gemstones_Carvings> Gemstones_Carvings { get; set; }
        public DbSet<Gemstones> Gemstones { get; set; }
        public DbSet<Jewelry> Jewelry { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentCard> PaymentCard { get; set; }

        // Constructor
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

    } // end class
} // end namespace
