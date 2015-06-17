using System.Data.Entity;
using KempsTuroTuro.DAL;
using System.Data.Entity.Migrations;

namespace KempsTuroTuro.Migrations
{


    internal sealed class Configuration : DropCreateDatabaseIfModelChanges<KempsContext>
    {
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
        }
    }
}
