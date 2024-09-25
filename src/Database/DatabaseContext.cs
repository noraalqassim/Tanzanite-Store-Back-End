using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Entity;
using Microsoft.EntityFrameworkCore;

namespace src.Database
{
    public class DatabaseContext : DbContext
    {

        // erd
        // category, product, user, order
        // category
        public DbSet<Category> Category { get; set; }
        // public DbSet<Product> Product { get; set; }


        // constructor
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            //
        }


        // static DatabaseContext()
        // {
        //     AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        //     AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        // }

    }
}