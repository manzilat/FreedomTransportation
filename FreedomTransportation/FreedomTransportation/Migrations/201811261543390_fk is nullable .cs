namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkisnullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransportationProviders", "DriverId", "dbo.Drivers");
            DropIndex("dbo.TransportationProviders", new[] { "DriverId" });
            AlterColumn("dbo.TransportationProviders", "DriverId", c => c.Int());
            CreateIndex("dbo.TransportationProviders", "DriverId");
            AddForeignKey("dbo.TransportationProviders", "DriverId", "dbo.Drivers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransportationProviders", "DriverId", "dbo.Drivers");
            DropIndex("dbo.TransportationProviders", new[] { "DriverId" });
            AlterColumn("dbo.TransportationProviders", "DriverId", c => c.Int(nullable: false));
            CreateIndex("dbo.TransportationProviders", "DriverId");
            AddForeignKey("dbo.TransportationProviders", "DriverId", "dbo.Drivers", "Id", cascadeDelete: true);
        }
    }
}
