namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtripsproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trips", "NameOfTheCustomer", c => c.String());
            AddColumn("dbo.Trips", "DriverName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trips", "DriverName");
            DropColumn("dbo.Trips", "NameOfTheCustomer");
        }
    }
}
