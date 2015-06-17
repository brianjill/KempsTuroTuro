using System;
using System.Collections.Generic;
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
                    Code = "tsp.",
                    EnglishMetricFlag = true,
                    Name = "teaspoon",
                    TypeCode = UnitOfMeasureType.Volume
                },
                new UnitOfMeasure
                {
                    Code = "tbsp.",
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
            };

            unitOfMeasures.ForEach(u=> context.UnitOfMeasures.AddOrUpdate(m=>m.Code, u));

            context.SaveChanges();
        }
    }
}
