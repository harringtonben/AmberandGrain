using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AmberAndGrain.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("Main") { }

        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}