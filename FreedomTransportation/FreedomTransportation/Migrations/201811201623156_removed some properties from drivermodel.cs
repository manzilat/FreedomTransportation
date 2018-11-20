namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedsomepropertiesfromdrivermodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drivers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Drivers", "TripsId", "dbo.Trips");
            DropIndex("dbo.Drivers", new[] { "CustomerId" });
            DropIndex("dbo.Drivers", new[] { "TripsId" });
            AlterColumn("dbo.Drivers", "CustomerId", c => c.Int());
            AlterColumn("dbo.Drivers", "TripsId", c => c.Int());
            CreateIndex("dbo.Drivers", "CustomerId");
            CreateIndex("dbo.Drivers", "TripsId");
            AddForeignKey("dbo.Drivers", "CustomerId", "dbo.Customers", "Id");
            AddForeignKey("dbo.Drivers", "TripsId", "dbo.Trips", "Id");
            DropColumn("dbo.Drivers", "DriverRating");
            DropColumn("dbo.Drivers", "lat");
            DropColumn("dbo.Drivers", "lng");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "lng", c => c.String());
            AddColumn("dbo.Drivers", "lat", c => c.String());
            AddColumn("dbo.Drivers", "DriverRating", c => c.String());
            DropForeignKey("dbo.Drivers", "TripsId", "dbo.Trips");
            DropForeignKey("dbo.Drivers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Drivers", new[] { "TripsId" });
            DropIndex("dbo.Drivers", new[] { "CustomerId" });
            AlterColumn("dbo.Drivers", "TripsId", c => c.Int(nullable: false));
            AlterColumn("dbo.Drivers", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Drivers", "TripsId");
            CreateIndex("dbo.Drivers", "CustomerId");
            AddForeignKey("dbo.Drivers", "TripsId", "dbo.Trips", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Drivers", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
