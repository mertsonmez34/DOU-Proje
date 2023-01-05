namespace E_Commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ECommercedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SKU = c.String(),
                        ProductName = c.String(),
                        IsPromoted = c.Boolean(nullable: false),
                        ProductDescription = c.String(),
                        SupplierID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                        AvailableSize = c.String(),
                        AvailableColors = c.String(),
                        Discount = c.Int(nullable: false),
                        UnitInStock = c.Boolean(nullable: false),
                        UnitsOnOrder = c.Short(nullable: false),
                        ProductAvailable = c.Boolean(nullable: false),
                        DiscountAvailable = c.Int(nullable: false),
                        Note = c.String(),
                        PictureURL = c.String(),
                        Ranking = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
