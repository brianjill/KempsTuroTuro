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
                    Id="Boil_Duck_Egg",
                    Name = "boiled duck egg",
                    AuthorizedForSaleFlag = false,
                    DiscountFlag = false,
                    PriceAuditFlag = false,
                    SubstituteIdentifiedFlag = false,
                    TypeCode = ItemType.Prepared,
                    Description = "itlog ng pato"
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

                },
                new Item
                {
                    Id="Flour",
                    Name = "flour",
                    AuthorizedForSaleFlag = true,
                    DiscountFlag = false,
                    PriceAuditFlag = false,
                    SubstituteIdentifiedFlag = false,
                    TypeCode = ItemType.Stock,
                    Description = "Harina"

                },
                new Item
                {
                    Id="Cornstarch",
                    Name = "cornstarch",
                    AuthorizedForSaleFlag = true,
                    DiscountFlag = false,
                    PriceAuditFlag = false,
                    SubstituteIdentifiedFlag = false,
                    TypeCode = ItemType.Stock,
                    Description = "Gawgaw"

                },
                new Item
                {
                    Id="Water",
                    Name = "water",
                    AuthorizedForSaleFlag = false,
                    DiscountFlag = false,
                    PriceAuditFlag = false,
                    SubstituteIdentifiedFlag = false,
                    TypeCode = ItemType.None,
                    Description = "Tubig"

                },
                new Item
                {
                    Id="Anatto_Powder",
                    Name = "anatto powder",
                    AuthorizedForSaleFlag = true,
                    DiscountFlag = false,
                    PriceAuditFlag = false,
                    SubstituteIdentifiedFlag = false,
                    TypeCode = ItemType.Stock,
                    Description = "pinulbos na atsuete"

                },
                new Item
                {
                    Id="Salt",
                    Name = "salt",
                    AuthorizedForSaleFlag = true,
                    DiscountFlag = false,
                    PriceAuditFlag = false,
                    SubstituteIdentifiedFlag = false,
                    TypeCode = ItemType.Stock,
                    Description = "asin"

                },
                new Item
                {
                    Id="Black_Pepper",
                    Name = "black pepper",
                    AuthorizedForSaleFlag = true,
                    DiscountFlag = false,
                    PriceAuditFlag = false,
                    SubstituteIdentifiedFlag = false,
                    TypeCode = ItemType.Stock,
                    Description = "paminta"

                },
                new Item
                {
                    Id="Frying_Oil",
                    Name = "frying oil",
                    AuthorizedForSaleFlag = true,
                    DiscountFlag = false,
                    PriceAuditFlag = false,
                    SubstituteIdentifiedFlag = false,
                    TypeCode = ItemType.Stock,
                    Description = "mantika"

                }
            };

            items.ForEach(u => context.Items.AddOrUpdate(m => m.Id, u));

            context.SaveChanges();
            
            var components = new List<RawMaterialComponent>
            {
                new RawMaterialComponent
                {
                    Id = 1,
                    ItemId = "Boil_Duck_Egg",
                    UnitOfMeasureCode = "pcs",
                    UnitAmount = 8,
                    Description = "8 pcs of boiled duck egg"
                },
                new RawMaterialComponent
                {
                    Id = 2,
                    ItemId = "Flour",
                    UnitOfMeasureCode = "cup",
                    UnitAmount = 1,
                    Description = "1 cup flour"
                },
                new RawMaterialComponent
                {
                    Id = 3,
                    ItemId = "Cornstarch",
                    UnitOfMeasureCode = "tbsp",
                    UnitAmount = 3,
                    Description = "3 tbsp cornstarch"
                },
                new RawMaterialComponent
                {
                    Id = 4,
                    ItemId = "Water",
                    UnitOfMeasureCode = "cup",
                    UnitAmount = (decimal)0.5,
                    Description = "1/2 cup water"
                },
                new RawMaterialComponent
                {
                    Id = 5,
                    ItemId = "Anatto_Powder",
                    UnitOfMeasureCode = "tbsp",
                    UnitAmount = 1,
                    Description = "1 tbsp anatto powder"
                },
                new RawMaterialComponent
                {
                    Id = 6,
                    ItemId = "Salt",
                    UnitOfMeasureCode = "tsp",
                    UnitAmount = (decimal) 0.5,
                    Description = "1/2 tsp salt"
                },
                new RawMaterialComponent
                {
                    Id = 7,
                    ItemId = "Black_Pepper",
                    UnitOfMeasureCode = "tsp",
                    UnitAmount = (decimal) 0.5,
                    Description = "1/2 tsp ground black pepper"
                },
                new RawMaterialComponent
                {
                    Id = 8,
                    ItemId = "Frying_Oil",
                    UnitOfMeasureCode = "cup",
                    UnitAmount = 2,
                    Description = "2 cup frying oil"
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
                    ServingsCount = 1,
                    CostInclusiveFlag = true,
                    WasteFlag = false,
                    KeyIngredientFlag = true
                },
                new RecipeLineItem
                {
                    RecipeId = 1,
                    RawMaterialComponentId = 2,
                    ServingsCount = 1,
                    CostInclusiveFlag = true,
                    WasteFlag = false,
                    KeyIngredientFlag = true
                },
                new RecipeLineItem
                {
                    RecipeId = 1,
                    RawMaterialComponentId = 3,
                    ServingsCount = 1,
                    CostInclusiveFlag = true,
                    WasteFlag = false,
                    KeyIngredientFlag = false
                },
                new RecipeLineItem
                {
                    RecipeId = 1,
                    RawMaterialComponentId = 4,
                    ServingsCount = 1,
                    CostInclusiveFlag = true,
                    WasteFlag = false,
                    KeyIngredientFlag = true
                },
                new RecipeLineItem
                {
                    RecipeId = 1,
                    RawMaterialComponentId = 5,
                    ServingsCount = 1,
                    CostInclusiveFlag = true,
                    WasteFlag = false,
                    KeyIngredientFlag = false
                },
                new RecipeLineItem
                {
                    RecipeId = 1,
                    RawMaterialComponentId = 6,
                    ServingsCount = 1,
                    CostInclusiveFlag = true,
                    WasteFlag = false,
                    KeyIngredientFlag = true
                },
                new RecipeLineItem
                {
                    RecipeId = 1,
                    RawMaterialComponentId = 7,
                    ServingsCount = 1,
                    CostInclusiveFlag = true,
                    WasteFlag = false,
                    KeyIngredientFlag = true
                },
                new RecipeLineItem
                {
                    RecipeId = 1,
                    RawMaterialComponentId = 8,
                    ServingsCount = 1,
                    CostInclusiveFlag = true,
                    WasteFlag = false,
                    KeyIngredientFlag = true
                }
            };

            ingredients.ForEach(u => context.RecipeLineItems.AddOrUpdate(m => new {m.RecipeId,m.RawMaterialComponentId}, u));

            context.SaveChanges();
            
        }
    }
}
