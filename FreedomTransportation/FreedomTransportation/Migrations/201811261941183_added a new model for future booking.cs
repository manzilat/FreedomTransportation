namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedanewmodelforfuturebooking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FutureSchedules",
                c => new
                    {
                        PickUpId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Time = c.String(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PickUpId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FutureSchedules", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.FutureSchedules", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.FutureSchedules", new[] { "ApplicationUserId" });
            DropIndex("dbo.FutureSchedules", new[] { "CustomerId" });
            DropTable("dbo.FutureSchedules");
        }
    }
}
