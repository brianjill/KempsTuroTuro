using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using KempsTuroTuro.DAL;
using KempsTuroTuro.Domain;

namespace KempsTuroTuro.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<KempsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KempsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var unitOfMeasures = new List<UnitOfMeasure>
            {
                new UnitOfMeasure
                {
                    Code = "tsp",
                    EnglishMetricFlag = true,
                    Name = "teaspoon",
                    TypeCode = UnitOfMeasureType.Volume
                },
                new UnitOfMeasure
                {
                    Code = "tbsp",
                    EnglishMetricFlag = true,
                    Name = "tablespoon",
                    TypeCode = UnitOfMeasureType.Volume
                },
                new UnitOfMeasure
                {
                    Code = "cup",
                    EnglishMetricFlag = true,
                    Name = "cup",
                    TypeCode = UnitOfMeasureType.Volume
                },

                new UnitOfMeasure
                {
                    Code = "ml",
                    EnglishMetricFlag = true,
                    Name = "milliliter",
                    TypeCode = UnitOfMeasureType.Volume
                },

                new UnitOfMeasure
                {
                    Code = "l",
                    EnglishMetricFlag = true,
                    Name = "litre",
                    TypeCode = UnitOfMeasureType.Volume
                },

                new UnitOfMeasure
                {
                    Code = "g",
                    EnglishMetricFlag = true,
                    Name = "milliliter",
                    TypeCode = UnitOfMeasureType.Weight
                },

                 new UnitOfMeasure
                {
                    Code = "pcs",
                    EnglishMetricFlag = false,
                    Name = "pieces",
                    TypeCode = UnitOfMeasureType.Each
                },
            };

            unitOfMeasures.ForEach(u=> context.UnitOfMeasures.AddOrUpdate(m=>m.Code, u));

            context.SaveChanges();


            var items = new List<Item>
            {
                new Item
                {
                    Id="Boil_Quail_Egg",
                    Name = "boiled quial egg",
                    AuthorizedForSaleFlag = false,
                    DiscountFlag = false,
                    PriceAuditFlag = false,
                    SubstituteIdentifiedFlag = false,
                    TypeCode = ItemType.Prepared,
                    Description = "itlog ng pugo"
                },
                new Item
                {
                    Id="Boil_Ch_Egg",
                    Name = "boiled chicken egg",
                    AuthorizedForSaleFlag = false,
                    DiscountFlag = false,
                    PriceAuditFlag = false,
                    SubstituteIdentifiedFlag = false,
                    TypeCode = ItemType.Prepared,
                    Description = "itlog ng manok"

                },
                new Item
                {
                    Id="Kwek",
                    Name = "kwek-kwek",
                    AuthorizedForSaleFlag = true,
                    DiscountFlag = false,
                    PriceAuditFlag = false,
                    SubstituteIdentifiedFlag = false,
                    TypeCode = ItemType.Prepared,
                    Description = "hard boiled eggs coated with batter and deep-fried"

                }
            };

            items.ForEach(u => context.Items.AddOrUpdate(m => m.Id, u));

            context.SaveChanges();
            
            var components = new List<RawMaterialComponent>
            {
                new RawMaterialComponent
                {
                    Id = 1,
                    ItemId = "Boil_Quail_Egg",
                    UnitOfMeasureCode = "pcs",
                    UnitAmount = 1,
                    Description = "1 pcs of boiled quial egg"
                }

            };

            components.ForEach(u => context.RawMaterialComponents.AddOrUpdate(m => m.Id, u));

            context.SaveChanges();

            //boiled chicken egg is susbtitue for quial eggs
            var componentItems = new List<RawMaterialComponentItem>
            {
                new RawMaterialComponentItem
                {
                    RawMaterialComponentId = 1,
                    ItemId = "Boil_Ch_Egg"
                }
            };
            componentItems.ForEach(u => context.RawMaterialComponentItems.AddOrUpdate(m => new { m.ItemId, m.RawMaterialComponentId }, u));

            context.SaveChanges();

            context.PreparedItems.AddOrUpdate(p => p.ItemId, new PreparedItem
            {
                ItemId = "Kwek",
                FoodItemHoldingTime = 10
            });
            context.SaveChanges();
            
            context.Recipes.AddOrUpdate(p => p.Id, new Recipe
            {
                Id = 1,
                CreateDate = DateTime.Now,
                StatusCode = RecipeStatus.Active,
                Description = "Kwek-kwek",
                ItemId = "Kwek",

                
            });
            context.SaveChanges();

            var ingredients = new List<RecipeLineItem>
            {
                new RecipeLineItem
                {
                    RecipeId = 1,
                    RawMaterialComponentId = 1,
                    ServingsCount = 18,
                    CostInclusiveFlag = true,
                    WasteFlag = false,
                    KeyIngredientFlag = true
                },

            };

            ingredients.ForEach(u => context.RecipeLineItems.AddOrUpdate(m => new {m.RecipeId,m.RawMaterialComponentId}, u));

            context.SaveChanges();
            
        }
    }
}
