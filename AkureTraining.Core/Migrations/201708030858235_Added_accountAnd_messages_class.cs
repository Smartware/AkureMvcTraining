namespace AkureTraining.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_accountAnd_messages_class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Customer_Name = c.String(),
                        Credit_Loaded = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sms_Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedBy_Id = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        ModifiedBy_Id = c.Int(),
                        ModifiedOnUtc = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.ModifiedBy_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Recipient_Name = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                        CreatedBy_Id = c.Int(nullable: false),
                        CreatedOnUtc = c.DateTime(nullable: false),
                        ModifiedBy_Id = c.Int(),
                        ModifiedOnUtc = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedBy_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.ModifiedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ModifiedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accounts", "ModifiedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accounts", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Messages", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Accounts", new[] { "ModifiedBy_Id" });
            DropIndex("dbo.Accounts", new[] { "CreatedBy_Id" });
            DropTable("dbo.Messages");
            DropTable("dbo.Accounts");
        }
    }
}
