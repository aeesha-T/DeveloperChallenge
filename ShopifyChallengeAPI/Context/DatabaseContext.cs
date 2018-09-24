using ShopifyChallengeAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopifyChallengeAPI.Context
{
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext() : base("DefaultConnection") {
          // Database.SetInitializer<DatabaseContext>(new DatabaseInitializer());
        }
       
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
    }
}