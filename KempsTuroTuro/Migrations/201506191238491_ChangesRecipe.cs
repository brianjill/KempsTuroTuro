namespace KempsTuroTuro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesRecipe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RawMaterialComponent", "UnitAmount", c => c.Decimal(nullable: false, precision: 3, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RawMaterialComponent", "UnitAmount", c => c.Decimal(nullable: false, precision: 3, scale: 0));
        }
    }
}
