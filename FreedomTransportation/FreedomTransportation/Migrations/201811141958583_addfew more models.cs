namespace FreedomTransportation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfewmoremodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "DriversLicense", c => c.String());
            AddColumn("dbo.Drivers", "Status", c => c.String());
            AddColumn("dbo.Drivers", "DriverRating", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "DriverRating");
            DropColumn("dbo.Drivers", "Status");
            DropColumn("dbo.Drivers", "DriversLicense");
        }
    }
}
