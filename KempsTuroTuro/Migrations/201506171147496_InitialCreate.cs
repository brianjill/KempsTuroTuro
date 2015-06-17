namespace KempsTuroTuro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 32),
                        AuthorizedForSaleFlag = c.Boolean(nullable: false),
                        DiscountFlag = c.Boolean(nullable: false),
                        PriceAuditFlag = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 40),
                        Description = c.String(maxLength: 255),
                        LongDescription = c.String(),
                        TypeCode = c.Int(nullable: false),
                        SubstituteIdentifiedFlag = c.Boolean(nullable: false),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.PreparedItem",
                c => new
                    {
                        ItemId = c.String(nullable: false, maxLength: 32),
                        FoodItemHoldingTime = c.Decimal(nullable: false, precision: 4, scale: 0),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.RawMaterialComponentItem",
                c => new
                    {
                        RawMaterialComponentId = c.Int(nullable: false),
                        ItemId = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.RawMaterialComponentId, t.ItemId })
                .ForeignKey("dbo.RawMaterialComponent", t => t.RawMaterialComponentId, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.RawMaterialComponentId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.RawMaterialComponent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.String(maxLength: 32),
                        UnitOfMeasureCode = c.String(maxLength: 128),
                        UnitAmount = c.Decimal(nullable: false, precision: 3, scale: 0),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.ItemId)
                .ForeignKey("dbo.UnitOfMeasure", t => t.UnitOfMeasureCode)
                .Index(t => t.ItemId)
                .Index(t => t.UnitOfMeasureCode);
            
            CreateTable(
                "dbo.UnitOfMeasure",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        EnglishMetricFlag = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 40),
                        TypeCode = c.Int(nullable: false),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.RecipeLineItem",
                c => new
                    {
                        RecipeId = c.Int(nullable: false),
                        RawMaterialComponentId = c.Int(nullable: false),
                        ServingsCount = c.Decimal(nullable: false, precision: 3, scale: 0),
                        CostInclusiveFlag = c.Boolean(nullable: false),
                        WasteFlag = c.Boolean(nullable: false),
                        KeyIngredientFlag = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.RecipeId, t.RawMaterialComponentId })
                .ForeignKey("dbo.RawMaterialComponent", t => t.RawMaterialComponentId, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.RawMaterialComponentId);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeVariationOf = c.Int(nullable: false),
                        LastChangeDate = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        StatusCode = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeLineItem", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Item", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.RecipeLineItem", "RawMaterialComponentId", "dbo.RawMaterialComponent");
            DropForeignKey("dbo.RawMaterialComponentItem", "ItemId", "dbo.Item");
            DropForeignKey("dbo.RawMaterialComponentItem", "RawMaterialComponentId", "dbo.RawMaterialComponent");
            DropForeignKey("dbo.RawMaterialComponent", "UnitOfMeasureCode", "dbo.UnitOfMeasure");
            DropForeignKey("dbo.RawMaterialComponent", "ItemId", "dbo.Item");
            DropForeignKey("dbo.PreparedItem", "ItemId", "dbo.Item");
            DropIndex("dbo.RecipeLineItem", new[] { "RawMaterialComponentId" });
            DropIndex("dbo.RecipeLineItem", new[] { "RecipeId" });
            DropIndex("dbo.RawMaterialComponent", new[] { "UnitOfMeasureCode" });
            DropIndex("dbo.RawMaterialComponent", new[] { "ItemId" });
            DropIndex("dbo.RawMaterialComponentItem", new[] { "ItemId" });
            DropIndex("dbo.RawMaterialComponentItem", new[] { "RawMaterialComponentId" });
            DropIndex("dbo.PreparedItem", new[] { "ItemId" });
            DropIndex("dbo.Item", new[] { "Recipe_Id" });
            DropTable("dbo.Recipe");
            DropTable("dbo.RecipeLineItem");
            DropTable("dbo.UnitOfMeasure");
            DropTable("dbo.RawMaterialComponent");
            DropTable("dbo.RawMaterialComponentItem");
            DropTable("dbo.PreparedItem");
            DropTable("dbo.Item");
        }
    }
}
