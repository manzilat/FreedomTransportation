namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drivers", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Drivers", new[] { "CustomerId" });
            DropColumn("dbo.Drivers", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "CustomerId", c => c.Int());
            CreateIndex("dbo.Drivers", "CustomerId");
            AddForeignKey("dbo.Drivers", "CustomerId", "dbo.Customers", "Id");
        }
    }
}
