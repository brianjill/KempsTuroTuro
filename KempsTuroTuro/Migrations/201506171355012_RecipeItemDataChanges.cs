namespace KempsTuroTuro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeItemDataChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "Recipe_Id", "dbo.Recipe");
            DropIndex("dbo.Item", new[] { "Recipe_Id" });
            AddColumn("dbo.Recipe", "ItemId", c => c.String(maxLength: 32));
            AlterColumn("dbo.Recipe", "RecipeVariationOf", c => c.Int());
            AlterColumn("dbo.Recipe", "LastChangeDate", c => c.DateTime());
            CreateIndex("dbo.Recipe", "ItemId");
            AddForeignKey("dbo.Recipe", "ItemId", "dbo.Item", "Id");
            DropColumn("dbo.Item", "Recipe_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "Recipe_Id", c => c.Int());
            DropForeignKey("dbo.Recipe", "ItemId", "dbo.Item");
            DropIndex("dbo.Recipe", new[] { "ItemId" });
            AlterColumn("dbo.Recipe", "LastChangeDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Recipe", "RecipeVariationOf", c => c.Int(nullable: false));
            DropColumn("dbo.Recipe", "ItemId");
            CreateIndex("dbo.Item", "Recipe_Id");
            AddForeignKey("dbo.Item", "Recipe_Id", "dbo.Recipe", "Id");
        }
    }
}
