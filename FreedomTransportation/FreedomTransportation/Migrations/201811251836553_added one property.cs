namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedoneproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsConfirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsConfirmed");
        }
    }
}
