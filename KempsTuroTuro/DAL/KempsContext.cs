using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using KempsTuroTuro.Domain;

namespace KempsTuroTuro.DAL
{
    public class KempsContext: DbContext
    {
        public KempsContext(): base("KempsContext")
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<PreparedItem> PreparedItems { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RawMaterialComponent> RawMaterialComponents { get; set; }
        public DbSet<RawMaterialComponentItem> RawMaterialComponentItems { get; set; }
        public DbSet<RecipeLineItem> RecipeLineItems { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<PreparedItem>().Property(x => x.FoodItemHoldingTime).HasPrecision(4, 0);
            modelBuilder.Entity<RawMaterialComponent>().Property(x => x.UnitAmount).HasPrecision(3, 0);
            modelBuilder.Entity<RecipeLineItem>().Property(x => x.ServingsCount).HasPrecision(3, 0);
        }
    }
}