namespace AkureTraining.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductUId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 150),
                        Description = c.String(maxLength: 250),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                        EntryDate = c.DateTime(),
                        Insert_UId = c.Guid(),
                        Update_UId = c.Guid(),
                        PhotoURL = c.String(maxLength: 250),
                        Extention = c.String(maxLength: 20),
                        FileName = c.String(maxLength: 150),
                        IsDiscountable = c.Boolean(nullable: false),
                        Barcode = c.String(maxLength: 250),
                        Notes = c.String(maxLength: 250),
                        CostPrice = c.Decimal(precision: 18, scale: 2),
                        ReorderLevel = c.Int(),
                        ContentType = c.String(maxLength: 50),
                        FileSize = c.Int(),
                        ExpiryDate = c.DateTime(),
                        CanExpire = c.Boolean(nullable: false),
                        Category_UId = c.Int(),
                        IsDiscontinued = c.Boolean(),
                        CreatedBy_Id = c.Int(),
                        ModifiedBy_Id = c.Int(),
                        ModifiedOnUtc = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.ModifiedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ModifiedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Product", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Product", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Product", new[] { "CreatedBy_Id" });
            DropTable("dbo.Product");
        }
    }
}
